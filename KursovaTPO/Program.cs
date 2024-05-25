using KursovaTPO.ArrayTools;
using KursovaTPO.MergeSortAlgorithms;
using KursovaTPO.Tests;

namespace KursovaTPO;

class Program
{
    static void Main(string[] args)
    {
        // int numberOfThreads = 4;
        // int[] array5 = ArrayGenerator.GenerateArray(5);
        // Console.WriteLine($"Array with {array5.Length} elements Before Sorting");
        // ArrayExtension.printArray(array5);
        // ArrayExtension.IsSorted(array5);
        // Console.WriteLine();
        // ParallelMergeSort.MergeSort(array5,numberOfThreads);
        // Console.WriteLine($"Array with {array5.Length} elements After Sorting");
        // ArrayExtension.printArray(array5);
        // ArrayExtension.IsSorted(array5);
        //
        // int[] array8 = ArrayGenerator.GenerateArray(8);
        // Console.WriteLine($"Array with {array8.Length} elements Before Sorting");
        // ArrayExtension.printArray(array8);
        // ArrayExtension.IsSorted(array8);
        // Console.WriteLine();
        // ParallelMergeSort.MergeSort(array8,numberOfThreads);
        // Console.WriteLine($"Array with {array8.Length} elements After Sorting");
        // ArrayExtension.printArray(array8);
        // ArrayExtension.IsSorted(array8);
        //
        // int[] array10 = ArrayGenerator.GenerateArray(10);
        // Console.WriteLine($"Array with {array10.Length} elements Before Sorting");
        // ArrayExtension.printArray(array10);
        // ArrayExtension.IsSorted(array10);
        // Console.WriteLine();
        // ParallelMergeSort.MergeSort(array10,numberOfThreads);
        // Console.WriteLine($"Array with {array10.Length} elements After Sorting");
        // ArrayExtension.printArray(array10);
        // ArrayExtension.IsSorted(array10);
        
        int[] threads = {2,4,8,16,32,64};
        int[] sizesForTesting =
        {
            100, 1_000, 2_500, 25_000, 50_000, 100_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 15_000_000, 20_000_000, 30_000_000,
            50_000_000, 100_000_000, 500_000_000
        }; 
        SortPerformanceTester.TestParallelSort(sizesForTesting,threads);
        SortPerformanceTester.TestSequentialSort(sizesForTesting);
    }
}
