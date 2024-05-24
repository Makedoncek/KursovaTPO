using KursovaTPO.Tests;

namespace KursovaTPO;

class Program
{
    static void Main(string[] args)
    {
        // int[] arr = ArrayGenerator.GenerateArray(500_000_000);
        // //Console.WriteLine("Given array is");
        // //ArrayExtension.printArray(arr);
        // ArrayExtension.IsSorted(arr);
        // Stopwatch sw = new Stopwatch();
        // sw.Start();
        // ParallelMergeSort.MergeSort(arr,4);
        // //Console.WriteLine("\nSorted array is");
        // //ArrayExtension.printArray(arr);
        // ArrayExtension.IsSorted(arr);
        // sw.Stop();
        // Console.WriteLine("\nParallel Merge Sort Time Is " + sw.ElapsedMilliseconds);
        //
        // int[] arr1 = ArrayGenerator.GenerateArray(500_000_000);
        // Console.WriteLine("Given array is");
        // //ArrayExtension.printArray(arr);
        // ArrayExtension.IsSorted(arr1);
        // Stopwatch sw1 = new Stopwatch();
        // SequentialMergeSort sequentialMergeSort = new SequentialMergeSort();
        // sw1.Start();
        // sequentialMergeSort.Sort(arr1, 0, arr1.Length - 1);
        // sw1.Stop();
        // Console.WriteLine("\nSorted array is");
        // //ArrayExtension.printArray(arr);
        // ArrayExtension.IsSorted(arr1);
        // Console.WriteLine("\nSequential Merge Sort Time Is " + sw1.ElapsedMilliseconds);
        int[] sizes = { 10000, 25000, 100000, 1_000_000, 10_000_000, 100_000_000 };
        int[] threads = { 2, 4, 8, 16 };
        SortPerformanceTester.TestSequentialSort(sizes);
    }
}
