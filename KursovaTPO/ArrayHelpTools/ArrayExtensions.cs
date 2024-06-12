namespace KursovaTPO.ArrayHelpTools
{
    using System;

    /// <summary>
    /// Provides utility methods for working with arrays, including printing, checking if sorted, and generating arrays.
    /// </summary>
    public static class ArrayExtensions
    {
        // Статичний екземпляр класу Random для використання у всіх методах.
        private static readonly Random Random = new Random();

        /// <summary>
        /// Prints the elements of the array to the console.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="arr">The array to be printed.</param>
        public static void PrintArray<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Checks if the array is sorted and prints the result to the console.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, which must implement IComparable<T>.</typeparam>
        /// <param name="arr">The array to check.</param>
        public static void IsSorted<T>(T[] arr) where T : IComparable<T>
        {
            if (IsSortedResult(arr))
            {
                Console.WriteLine("Array Sorted");
            }
            else
            {
                Console.WriteLine("Array not Sorted");
            }
        }

        /// <summary>
        /// Generates an array of the specified size with random double values between 0 and 100000.
        /// </summary>
        /// <param name="size">The size of the array to generate.</param>
        /// <returns>A double array filled with random values.</returns>
        public static double[] GenerateArray(int size)
        {
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Round(Random.NextDouble() * 100000, 4);
            }

            return array;
        }

        /// <summary>
        /// Determines whether the specified array is sorted in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, which must implement IComparable<T>.</typeparam>
        /// <param name="array">The array to check.</param>
        /// <returns>True if the array is sorted in ascending order; otherwise, false.</returns>
        private static bool IsSortedResult<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
