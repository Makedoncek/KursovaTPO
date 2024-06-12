using KursovaTPO.ArrayHelpTools;
using KursovaTPO.MergeSortAlgorithms;
using System.Diagnostics;

namespace KursovaTPO.Tests
{
    /// <summary>
    /// Class for testing the performance of sorting algorithms.
    /// </summary>
    public class SortPerformanceTester
    {
        private const int DefaultTrials = 5;

        /// <summary>
        /// Tests the performance of the sequential merge sort.
        /// </summary>
        /// <param name="sizes">Array sizes to test.</param>
        /// <param name="trials">Number of trials for each size. Default is 5.</param>
        public static void TestSequentialMergeSort(int[] sizes, int trials = DefaultTrials)
        {
            foreach (int size in sizes)
            {
                double averageTime = RunTrials(size, trials, SequentialMergeSort<double>.Sort);
                Console.WriteLine($"Average SequentialMergeSort time for {size} elements over {trials} trials: {averageTime} ms\n");
            }
        }

        /// <summary>
        /// Tests the performance of the parallel merge sort.
        /// </summary>
        /// <param name="sizes">Array sizes to test.</param>
        /// <param name="threads">Array of thread counts to test.</param>
        /// <param name="trials">Number of trials for each size and thread count. Default is 5.</param>
        public static void TestParallelMergeSort(int[] sizes, int[] threads, int trials = DefaultTrials)
        {
            foreach (int size in sizes)
            {
                foreach (int thread in threads)
                {
                    double averageTime = RunParallelTrials(size, thread, trials);
                    Console.WriteLine($"Average ParallelMergeSort time for {size} elements with {thread} threads over {trials} trials: {averageTime} ms\n");
                }
            }
        }

        /// <summary>
        /// Tests the performance of the parallel merge sort with various thresholds.
        /// </summary>
        /// <param name="sizes">Array sizes to test.</param>
        /// <param name="thresholds">Array of threshold values to test.</param>
        /// <param name="trials">Number of trials for each size and threshold. Default is 5.</param>
        public static void TestParallelMergeSortWithThresholds(int[] sizes, int[] thresholds, int trials = DefaultTrials)
        {
            int maxThreads = Environment.ProcessorCount;
            foreach (int size in sizes)
            {
                foreach (int threshold in thresholds)
                {
                    double averageTime = RunParallelTrialsWithThreshold(size, threshold, maxThreads, trials);
                    Console.WriteLine($"Average ParallelMergeSort time for {size} elements with threshold {threshold} and {maxThreads} threads over {trials} trials: {averageTime} ms\n");
                }
            }
        }

        /// <summary>
        /// Runs the trials for the specified sort method and calculates the average time.
        /// </summary>
        /// <param name="size">The size of the array to sort.</param>
        /// <param name="trials">The number of trials to run.</param>
        /// <param name="sortMethod">The sorting method to test.</param>
        /// <returns>The average time in milliseconds for the sorting method over the specified number of trials.</returns>
        private static double RunTrials(int size, int trials, Action<double[]> sortMethod)
        {
            double totalMilliseconds = 0;
            for (int trial = 0; trial < trials; trial++)
            {
                double[] array = ArrayExtensions.GenerateArray(size);
                Stopwatch sw = Stopwatch.StartNew();
                sortMethod(array);
                sw.Stop();
                totalMilliseconds += sw.Elapsed.TotalMilliseconds;
            }
            return totalMilliseconds / trials;
        }

        /// <summary>
        /// Runs the trials for the parallel merge sort and calculates the average time.
        /// </summary>
        /// <param name="size">The size of the array to sort.</param>
        /// <param name="thread">The number of threads to use.</param>
        /// <param name="trials">The number of trials to run.</param>
        /// <returns>The average time in milliseconds for the parallel merge sort over the specified number of trials.</returns>
        private static double RunParallelTrials(int size, int thread, int trials)
        {
            double totalMilliseconds = 0;
            for (int trial = 0; trial < trials; trial++)
            {
                double[] array = ArrayExtensions.GenerateArray(size);
                int threshold = array.Length / thread;
                Stopwatch sw = Stopwatch.StartNew();
                ParallelMergeSort<double>.Sort(array, threshold, thread);
                sw.Stop();
                totalMilliseconds += sw.Elapsed.TotalMilliseconds;
            }
            return totalMilliseconds / trials;
        }

        /// <summary>
        /// Runs the trials for the parallel merge sort with a specific threshold and calculates the average time.
        /// </summary>
        /// <param name="size">The size of the array to sort.</param>
        /// <param name="threshold">The threshold value to use for switching to sequential sort.</param>
        /// <param name="threads">The number of threads to use.</param>
        /// <param name="trials">The number of trials to run.</param>
        /// <returns>The average time in milliseconds for the parallel merge sort over the specified number of trials.</returns>
        private static double RunParallelTrialsWithThreshold(int size, int threshold, int threads, int trials)
        {
            double totalMilliseconds = 0;
            for (int trial = 0; trial < trials; trial++)
            {
                double[] array = ArrayExtensions.GenerateArray(size);
                Stopwatch sw = Stopwatch.StartNew();
                ParallelMergeSort<double>.Sort(array, threshold, threads);
                sw.Stop();
                totalMilliseconds += sw.Elapsed.TotalMilliseconds;
            }
            return totalMilliseconds / trials;
        }
    }
}
