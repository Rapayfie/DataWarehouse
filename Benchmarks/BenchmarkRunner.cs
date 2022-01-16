using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse.Commons.Attributes;
using DataWarehouse.Commons.Generators;

namespace DataWarehouse.Benchmarks
{
    public static class BenchmarkRunner
    {
        #region Implementation
        public static async Task Run<T>() where T : Benchmark
        {
            await BenchmarkOutputGenerator.WritePreprocessingInformation();
            var methodInfos = GetMethods(typeof(T));
            object classInstance = Activator.CreateInstance(typeof(T), null);
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var methodInfo in methodInfos)
            {
                var attribute = methodInfo.GetCustomAttribute<BenchmarkAttribute>();
                stringBuilder.AppendLine(attribute.Description);
                stringBuilder.AppendLine(attribute.SqlEquivalentStatement);
                
                //BEGIN RUNNING TIME CALCULATIONS
                var watch = System.Diagnostics.Stopwatch.StartNew();
                methodInfo.Invoke(classInstance, null);
                watch.Stop();
                stringBuilder.AppendLine($"Running time: {watch.ElapsedMilliseconds.ToString()}");
            }
            await BenchmarkOutputGenerator.WriteInformation(stringBuilder.ToString());
        }

        private static MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }
        #endregion
    }
}