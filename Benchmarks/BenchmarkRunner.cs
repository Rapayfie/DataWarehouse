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
            var methodInfos = GetMethods(classType);
            object classInstance = Activator.CreateInstance(typeof(T), null);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"--> Benchmark for: {classType.Namespace}.{classType.Name}");
            
            foreach (var methodInfo in methodInfos)
            {
                var a = typeof(T).Namespace;
                GetBenchmarkAttributeDescriptions(ref stringBuilder, methodInfo);
                var timeElapsed = GetRunningTimeOfMethod(methodInfo, classInstance);
                stringBuilder.AppendLine($"Running time: {timeElapsed}");
                stringBuilder.AppendLine();
            }

            BenchmarkOutputGenerator.WriteInformation(stringBuilder.ToString());
        }

        private static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }

        private static void GetBenchmarkAttributeDescriptions(ref StringBuilder stringBuilder, MethodInfo methodInfo)
        {
            var attribute = methodInfo.GetCustomAttribute<BenchmarkAttribute>();
            stringBuilder.AppendLine(attribute.Description);
            stringBuilder.AppendLine(attribute.SqlEquivalentStatement);
        }

        private static long GetRunningTimeOfMethod(MethodInfo methodInfo, object classInstance)
        {
            var watch = Stopwatch.StartNew();
            methodInfo.Invoke(classInstance, null);
            watch.Stop();
            
            return watch.ElapsedMilliseconds;
        }
        #endregion
    }
}