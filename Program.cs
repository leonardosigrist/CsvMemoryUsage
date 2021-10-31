using System;
using System.Diagnostics;

namespace MemorySizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            var timer = new Stopwatch();
            var counter = 0;

            timer.Start();

            foreach (var pa in fileService.GetCsvCollection())
            {
                if (counter % 10_000 == 0)
                {
                    Console.WriteLine($"Memory: {GetMemoryAllocated()} Mb");
                }

                counter++;
            }

            timer.Stop();
            Console.WriteLine("Time taken: " + timer.Elapsed.ToString(@"m\:ss\.fff"));
            Console.WriteLine($"Final memory: {GetMemoryAllocated()} Mb");
        }

        private static double GetMemoryAllocated()
        {
            var allocatedMemoryBytes = GC.GetTotalAllocatedBytes();
            var allocatedMemoryMegaBytes = Math.Round(allocatedMemoryBytes * (9.537 * Math.Pow(10, -7)), 3);

            return allocatedMemoryMegaBytes;
        }
    }
}
