using KursovaTPO.ArrayTools;
using KursovaTPO.MergeSortAlgorithms;

namespace KursovaTPO.Tests;
using System;
using System.Diagnostics;
using System.Linq;

// Клас для виконання тестування продуктивності алгоритмів сортування.
class SortPerformanceTester
{
    // Метод для тестування послідовної реалізації сортування.
    public static void TestSequentialSort(int[] sizes)
    {
        // Ітерація через різні розміри масиву для тестування.
        foreach (int size in sizes)
        {
            double totalMilliseconds = 0;
            int trials = 5; // Кількість пробігів для кожної розмірності.

            // Проведення декількох випробувань для отримання середнього часу.
            for (int trial = 0; trial < trials; trial++)
            {
                int[] array = ArrayGenerator.GenerateArray(size); // Генерація масиву.
                var sort = new SequentialMergeSort(); // Створення екземпляра сортувальника.

                Stopwatch sw = Stopwatch.StartNew(); // Запуск таймера.
                sort.Sort(array, 0, array.Length - 1); // Виконання сортування.
                sw.Stop(); // Зупинка таймера.

                totalMilliseconds += sw.Elapsed.TotalMilliseconds; // Накопичення часу виконання.
                Console.WriteLine($"Sequential Sort time for {size} elements at trial {trial+1}: {sw.Elapsed.TotalMilliseconds} ms");
            }

            double averageMilliseconds = totalMilliseconds / trials; // Обчислення середнього часу.
            Console.WriteLine($"Average Sequential Sort time for {size} elements over {trials} trials: {averageMilliseconds} ms\n");
        }
    }

    // Метод для тестування паралельної реалізації сортування.
    public static void TestParallelSort(int[] sizes, int[] processorCounts)
    {
        // Ітерація через різні розміри та кількості потоків.
        foreach (int size in sizes)
        {
            foreach (int count in processorCounts)
            {
                double totalMilliseconds = 0;
                int trials = 5; // Кількість пробігів для кожного набору параметрів.

                // Проведення декількох випробувань для отримання середнього часу.
                for (int trial = 0; trial < trials; trial++)
                {
                    int[] array = ArrayGenerator.GenerateArray(size); // Генерація масиву.
                    
                    Stopwatch sw = Stopwatch.StartNew(); // Запуск таймера.
                    ParallelMergeSort.MergeSort(array, count); // Виконання паралельного сортування.
                    sw.Stop(); // Зупинка таймера.
                    
                    totalMilliseconds += sw.Elapsed.TotalMilliseconds; // Накопичення часу виконання.
                    Console.WriteLine($"Parallel Merge Sort time for {size} elements with {count} threads at trial {trial+1}: {sw.Elapsed.TotalMilliseconds} ms");
                }

                double averageMilliseconds = totalMilliseconds / trials; // Обчислення середнього часу.
                Console.WriteLine($"Average Parallel Merge Sort time for {size} elements with {count} threads over {trials} trials: {averageMilliseconds} ms\n");
            }
        }
    }
}
