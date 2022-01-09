using System;
using System.Linq;
using System.Reflection;
using DataWarehouse.Commons.Attributes;
using DataWarehouse.Commons.Generators;

namespace DataWarehouse.Benchmarks
{
    public static class BenchmarkRunner
    {
        private static readonly BenchmarkOutputGenerator BenchmarkOutputGenerator;

        static BenchmarkRunner()
        {
            BenchmarkOutputGenerator = BenchmarkOutputGenerator.GetInstance();
        }
        
        public static async void Run<T>() where T : class
        {
            await BenchmarkOutputGenerator.WritePreprocessingInformation();

            var methodInfos = GetAllMethodsWithBenchmarkAttribute(typeof(T));

            foreach (var method in methodInfos)
            {
                //method.Invoke()
            }
        }

        private static MethodInfo[] GetAllMethodsWithBenchmarkAttribute(Type type)
        {
            return type.Assembly.GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(BenchmarkAttribute), false).Length > 0)
                .ToArray();
        }
    }
}