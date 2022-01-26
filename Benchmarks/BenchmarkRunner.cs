using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using DataWarehouse.Commons.Attributes;
using DataWarehouse.Commons.Generators;

namespace DataWarehouse.Benchmarks
{
    public static class BenchmarkRunner
    {
        #region Constructor
        static BenchmarkRunner()
        {
            BenchmarkOutputGenerator.WritePreprocessingInformation();
        }
        #endregion
        
        #region Implementation
        public static void Run<T>() where T : Benchmark
        {
            var classType = typeof(T);
            object classInstance = Activator.CreateInstance(classType, null);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"--> Benchmark for: {classType.Namespace}.{classType.Name}");

            foreach (MethodInfo method in typeof(T).GetMethods())
            {
                var attribute = method.GetCustomAttribute<BenchmarkAttribute>();
                if (attribute != null)
                {
                    stringBuilder.AppendLine(attribute.Description);
                    stringBuilder.AppendLine(attribute.SqlEquivalentStatement);
                    foreach (var value in attribute.Values)
                    {
                        if (classType.Name.StartsWith("S"))
                        {
                            PrepareData<T>(classInstance, value);
                            var timeElapsed = GetRunningTimeOfMethod(method, classInstance);
                            stringBuilder.AppendLine(
                                $"Number of records {value}^3: {Math.Pow(value, 3)}, Running time: {timeElapsed}");
                        }
                        else
                        {
                            var timeElapsed = GetRunningTimeOfInsertMethod(method, classInstance, value);
                            stringBuilder.AppendLine(
                                $"Number of records {value}^3: {Math.Pow(value, 3)}, Running time: {timeElapsed}");
                        }
                    }
                    stringBuilder.AppendLine();
                }
            }

            BenchmarkOutputGenerator.WriteInformation(stringBuilder.ToString());
        }

        private static long GetRunningTimeOfMethod(MethodInfo methodInfo, object classInstance)
        {
            var watch = Stopwatch.StartNew();
            methodInfo.Invoke(classInstance, null);
            watch.Stop();
            
            return watch.ElapsedMilliseconds;
        }

        private static long GetRunningTimeOfInsertMethod(MethodInfo methodInfo, object classInstance, int numberOfRecords)
        {
            var watch = Stopwatch.StartNew();
            methodInfo.Invoke(classInstance, new object[]{numberOfRecords});
            watch.Stop();
            
            return watch.ElapsedMilliseconds;
        }
        
        private static void PrepareData<T>(object classInstance, int numberOfRecords)
        {
            MethodInfo methodInfo = typeof(T).GetMethod("PrepareDb");
            methodInfo.Invoke(classInstance, new object[]{numberOfRecords});
        }
        
        #endregion
    }
}