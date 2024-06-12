namespace KursovaTPO.MergeSortAlgorithms
{
    using System;

    /// <summary>
    /// Provides an implementation of the merge sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array to be sorted.</typeparam>
    public class SequentialMergeSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts an array using the merge sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        public static void Sort(T[] arr)
        {
            T[] temp = new T[arr.Length];
            MergeSort(arr, temp, 0, arr.Length - 1);
        }

        /// <summary>
        /// Recursively sorts subarrays and then merges them.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <param name="temp">Temporary array used for merging.</param>
        /// <param name="low">The starting index of the subarray.</param>
        /// <param name="high">The ending index of the subarray.</param>
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

        /// <summary>
        /// Merges two sorted subarrays into a single sorted subarray.
        /// </summary>
        /// <param name="arr">The original array containing the subarrays to be merged.</param>
        /// <param name="temp">Temporary array to hold merged results.</param>
        /// <param name="low">The starting index of the first subarray.</param>
        /// <param name="mid">The ending index of the first subarray.</param>
        /// <param name="high">The ending index of the second subarray.</param>
        private static void Merge(T[] arr, T[] temp, int low, int mid, int high)
        {
            int i = low, j = mid + 1, k = low;
            // Merge the two sorted subarrays into a temporary array.
            while (i <= mid && j <= high)
            {
                temp[k++] = arr[i].CompareTo(arr[j]) <= 0 ? arr[i++] : arr[j++];
            }

            // Copy the remaining elements of left subarray, if any.
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            // Copy the remaining elements of right subarray, if any.
            while (j <= high)
            {
                temp[k++] = arr[j++];
            }

            // Copy the merged temporary array to the original array.
            Array.Copy(temp, low, arr, low, high - low + 1);
        }
    }
}
