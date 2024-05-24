namespace KursovaTPO.MergeSortAlgorithms;
using System;
using System.Threading.Tasks;

// Клас для паралельного сортування злиттям
class ParallelMergeSort
{
    // Головна методика сортування злиттям, яка використовує паралелізм
    public static void MergeSort(int[] array, int numberOfProcessors)
    {
        int n = array.Length;
        int h = numberOfProcessors;
        int logP = (int)Math.Log2(numberOfProcessors);  // Визначення кількості рівнів глибини злиття

        // Крок 1: Локальне сортування кожного підмасиву паралельно
        Parallel.For(0, numberOfProcessors, i =>
        {
            int start = i * (n / numberOfProcessors);  // Початок підмасиву
            int end = (i == numberOfProcessors - 1) ? n : (i + 1) * (n / numberOfProcessors);  // Кінець підмасиву
            Array.Sort(array, start, end - start);  // Сортування підмасиву
        });

        // Крок 2: Паралельне злиття відсортованих підмасивів
        for (int j = 0; j < logP; j++)
        {
            int currentH = h / (int)Math.Pow(2, j + 1);  // Кількість активних потоків на поточному рівні
            Parallel.For(0, currentH, i =>
            {
                int start = i * (2 * (n / (currentH * 2)));  // Початок злиття
                int mid = start + (n / (currentH * 2));  // Середина злиття
                int end = start + 2 * (n / (currentH * 2));  // Кінець злиття
                if (i == currentH - 1 && currentH * 2 < h) // Перевірка для останнього масиву
                {
                    end = n;  // Забезпечує, що останній масив включає всі залишкові елементи
                }

                int[] merged = new int[end - start];
                Merge(array, start, mid, end, merged);
                Array.Copy(merged, 0, array, start, merged.Length);
            });
        }
    }

    // Метод для злиття двох відсортованих підмасивів у один
    private static void Merge(int[] array, int left, int middle, int right, int[] result)
    {
        int i = left;  // Початковий індекс для лівої частини
        int j = middle;  // Початковий індекс для правої частини
        int k = 0;  // Індекс для результуючого масиву

        // Злиття двох масивів у відсортованому порядку
        while (i < middle && j < right)
        {
            if (array[i] <= array[j])
            {
                result[k++] = array[i++];
            }
            else
            {
                result[k++] = array[j++];
            }
        }

        // Копіювання залишилися елементів з лівого підмасиву
        while (i < middle)
        {
            result[k++] = array[i++];
        }

        // Копіювання залишилися елементів з правого підмасиву
        while (j < right)
        {
            result[k++] = array[j++];
        }
    }
}
