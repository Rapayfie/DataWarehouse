using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Management;
using System.Reflection;
using System.Text;

namespace DataWarehouse.Commons.Generators
{
    public static class BenchmarkOutputGenerator
    {
        #region Fields
        private const string DirectoryName = "Benchmarks.Data";
        private static string _fileName;
        private static string _path;
        private static readonly Dictionary<string, List<string>> PcInfoDictionary;
        #endregion

        #region Constructor
        static BenchmarkOutputGenerator()
        {
            if (!Directory.Exists(DirectoryName))
                Directory.CreateDirectory(DirectoryName);
            
            CreateFileWithCurrentDate();
            PcInfoDictionary = new Dictionary<string, List<string>>()
            {
                {"Processor", new List<string>(){"Name", "NumberOfLogicalProcessors"}},
                {"DiskDrive", new List<string>(){"Model"}},
                {"PhysicalMemory", new List<string>(){"Capacity", "Speed"}},
            };
        }
        #endregion

        #region Implementation
        private static void CreateFileWithCurrentDate()
        {
            _fileName = $"Benchmark_{DateTime.Now:yyyyMMdd_hhmmss}";
            _path = System.IO.Path.Combine(DirectoryName, _fileName);
            File.Create(_path).Close();
        }
        
        public static async Task WritePreprocessingInformation()
        {
            await WriteBeginningDialog();
            await WritePcSpecs();
            await WriteModelsInfo();
        }

        public static async Task WriteInformation(string information)
        {
            await using StreamWriter sw = File.AppendText(_path);
            await sw.WriteLineAsync(information);
        }
        
        private static async Task WriteBeginningDialog()
        {
            string text = @"--> Beginning benchmarks of sql operations on databases...";
            
            await File.WriteAllLinesAsync(_path, text.Split('\n'));
        }

        private static async Task WritePcSpecs()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("******Pc specs: ******");
            
            foreach(KeyValuePair<string, List<string>> entry in PcInfoDictionary)
            {
                foreach (var value in entry.Value)
                {
                    var componentValues = GetComponent(entry.Key, value);
                    foreach (var component in componentValues)
                    {
                        stringBuilder.AppendLine($"{entry.Key.ToString()}  {value.ToString()}  {component}");
                    }
                }
            }
            stringBuilder.AppendLine();
            using (StreamWriter sw = File.AppendText(_path))
            {
                await sw.WriteLineAsync(stringBuilder.ToString());
            }
        }

        private static List<string> GetComponent(string hwclass, string syntax)
        {
            var list = new List<string>();
            
            ManagementObjectSearcher mos = 
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_" + hwclass);
            
            foreach (ManagementObject mj in mos.Get())
            {
                if (Convert.ToString(mj[syntax]) != "")
                    list.Add(Convert.ToString(mj[syntax]));
            }

            return list;
        }
        
        private static async Task WriteModelsInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("******Models used for testing: ******");
            var ns = "DataWarehouse.Models";
            
            var classesFromAssembly = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == ns)
                .ToList();

            foreach (var classFromAssembly in classesFromAssembly)
            {
                stringBuilder.AppendLine("Model: " + classFromAssembly.Name);
                var properties = classFromAssembly.GetProperties();
                foreach (var property in properties)
                {
                    stringBuilder.AppendLine(property.Name);
                }

                stringBuilder.AppendLine();
            }
            
            using (StreamWriter sw = File.AppendText(_path))
            {
                await sw.WriteLineAsync(stringBuilder.ToString());
            }
        }
        
        public static async Task WritePostprocessingInformation()
        {
            await WriteEndDialog();
        }
        
        private static async Task WriteEndDialog()
        {
            string text = @"--> End of benchmarks of sql operations on databases...";
            await File.WriteAllTextAsync(_path, text);
        }
        #endregion
    }
}