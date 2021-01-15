using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestingAsyncSync
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Starting test...");
            // await TrueMultipleAsync();
            await FakeMultipleAsync();
            Console.WriteLine("Finished test...");
            Console.WriteLine($"Test duration: {sw.ElapsedMilliseconds} ms");
        }

        public static async Task FakeMultipleAsync()
        {
            var fakeTasks = Enumerable.Range(1, 10).Select(SingleFakeAsyncOperation);
            await Task.WhenAll(fakeTasks);
        }

        public static async Task TrueMultipleAsync()
        {
            var trueTasks = Enumerable.Range(1, 10).Select(SingleTrueAsyncOperation);
            await Task.WhenAll(trueTasks);
        }

        public static async Task SingleTrueAsyncOperation(int taskNumber)
        {
            Console.WriteLine($"Doing task with number: {taskNumber}");
            await Task.Delay(5000);
            Console.WriteLine($"Finished task with number: {taskNumber}");
        }

        public static async Task SingleFakeAsyncOperation(int taskNumber)
        {
            Console.WriteLine($"Doing task with number: {taskNumber}");
            Thread.Sleep(5000);
            Console.WriteLine($"Finished task with number: {taskNumber}");
        }
    }
}
