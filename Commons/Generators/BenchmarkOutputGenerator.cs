using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Management;

namespace DataWarehouse.Commons.Generators
{
    public sealed class BenchmarkOutputGenerator
    {
        private static BenchmarkOutputGenerator _instance;
        private string _directoryName = "Benchmarks.Data";
        private string _fileName;
        private string _path;
        
        private BenchmarkOutputGenerator()
        {
            if (!Directory.Exists(_directoryName))
                Directory.CreateDirectory(_directoryName);
            
            CreateFileWithCurrentDate();
        }

        private void CreateFileWithCurrentDate()
        {
            _fileName = $"Benchmark_{DateTime.Now:yyyyMMdd_hhmmss}";
            _path = Path.Combine(_directoryName, _fileName);
            File.Create(_path);
        }

        public static BenchmarkOutputGenerator GetInstance() =>
            _instance ??= new BenchmarkOutputGenerator();
        
        public async Task WritePreprocessingInformation()
        {
            await WriteBeginningDialog();
            await WritePcSpecs();
            await WriteModelsInfo();
        }

        private async Task WriteBeginningDialog()
        {
            string text = @"--> Beginning benchmarks of sql operations on databases...";
            var a = DriveInfo.GetDrives();
            
            await File.WriteAllTextAsync(_path, text);
        }

        private async Task WritePcSpecs()
        {
            
            string text = @"--> Beginning benchmarks of sql operations on databases...";
            await File.WriteAllTextAsync(_path, text);
        }

        private static void GetComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = 
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            
            foreach (ManagementObject mj in mos.Get())
            {
                if (Convert.ToString(mj[syntax]) != "")
                    Console.WriteLine(Convert.ToString(mj[syntax]));
            }
        }
        
        private async Task WriteModelsInfo()
        {
            await WritePcSpecs();
        }
        
        public async Task WritePostprocessingInformation()
        {
            await WriteEndDialog();
        }
        
        private async Task WriteEndDialog()
        {
            string text = @"--> End of benchmarks of sql operations on databases...";
            await File.WriteAllTextAsync(_path, text);
        }
    }
}