namespace KursovaTPO.MergeSortAlgorithms
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a parallel implementation of the merge sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array to be sorted, which must implement IComparable<T>.</typeparam>
    public class ParallelMergeSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Public method to start the parallel merge sort.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <param name="threshold">The size threshold below which to use sequential sort.</param>
        /// <param name="threadNum">The maximum degree of parallelism.</param>
        public static void Sort(T[] arr, int threshold, int threadNum)
        {
            T[] temp = new T[arr.Length];
            var options = new ParallelOptions { MaxDegreeOfParallelism = threadNum };
            ParallelMergeSortRecursive(arr, temp, 0, arr.Length-1, threshold, options);
        }

        /// <summary>
        /// Internal method to handle recursive parallel sorting.
        /// </summary>
        private static void ParallelMergeSortRecursive(T[] arr, T[] temp, int low, int high, int threshold, ParallelOptions options)
        {
            if (high - low + 1 <= threshold)
            {
                MergeSort(arr, temp, low, high);
            }
            else
            {
                int mid = low + (high - low) / 2;
                Parallel.Invoke(options,
                    () => ParallelMergeSortRecursive(arr, temp, low, mid, threshold, options),
                    () => ParallelMergeSortRecursive(arr, temp, mid + 1, high, threshold, options)
                );
                Merge(arr, temp, low, mid, high);
            }
        }

        /// <summary>
        /// Performs the merge operation to combine two sorted subarrays into one.
        /// </summary>
        private static void Merge(T[] arr, T[] temp, int low, int mid, int high)
        {
            int i = low, j = mid + 1, k = low;
            while (i <= mid && j <= high)
            {
                temp[k++] = arr[i].CompareTo(arr[j]) <= 0 ? arr[i++] : arr[j++];
            }

            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= high)
            {
                temp[k++] = arr[j++];
            }

            Array.Copy(temp, low, arr, low, high - low + 1);
        }

        /// <summary>
        /// A sequential merge sort used when the subarray size is below the threshold.
        /// </summary>
        private static void MergeSort(T[] arr, T[] temp, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;
                MergeSort(arr, temp, low, mid);
                MergeSort(arr, temp, mid + 1, high);
                Merge(arr, temp, low, mid, high);
            }
        }
    }
}