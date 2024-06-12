using KursovaTPO.ArrayHelpTools;
using KursovaTPO.MergeSortAlgorithms;
using KursovaTPO.Tests;

namespace KursovaTPO;

class Program
{
    static void Main(string[] args)
    {
         int[] threads = { 2, 4, 8, 16 };
        
         
         int[] sizesForM = {500_000, 1_000_000, 2_000_000, 4_000_000, 8_000_000, 12_000_000, 16_000_000, 20_000_000, 32_000_000 };
         int[] thresholds = { 8, 16, 32, 64, 128, 256, 512, 1024 };
         
         //var arr = new string[] { "dog", "cat", "pink", "merge" };
         //var comparer = Comparer<string>.Default; 
        
         //double[] array = ArrayExtensions.GenerateArray(100_000_000);
         //ArrayExtension.PrintArray(array);
         //ArrayExtensions.IsSorted(array);
         SortPerformanceTester.TestParallelMergeSortWithThresholds(sizesForM,thresholds);
         //SortPerformanceTester.TestSequentialMergeSort(sizesForM);
         //SortPerformanceTester.TestParallelMergeSort(sizesForM,threads);
         //ArrayExtension.PrintArray(array);
         //ArrayExtensions.IsSorted(array);
         

    }
}
