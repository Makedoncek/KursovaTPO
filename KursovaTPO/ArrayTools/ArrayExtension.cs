namespace KursovaTPO.ArrayTools;

// Клас розширень для роботи з масивами.
public static class ArrayExtension
{
    // Функція для виведення елементів масиву на консоль.
    public static void printArray(int[] arr)
    {
        int n = arr.Length;  // Зберігаємо довжину масиву для оптимізації доступу.
        for (int i = 0; i < n; ++i)  // Перебираємо всі елементи масиву.
            Console.Write(arr[i] + " ");  // Виводимо кожен елемент на екран.
        Console.WriteLine();  // Переводимо строку після завершення виведення масиву.
    }

    // Метод для перевірки, чи є масив відсортованим.
    public static void IsSorted(int[] arr)
    {
        if (IsSortedResult(arr))  // Викликаємо допоміжний метод, який перевіряє масив на відсортованість.
        {
            Console.WriteLine("Array Sorted");  // Якщо масив відсортований, виводимо повідомлення.
        }
        else
        {
            Console.WriteLine("Array not Sorted");  // Якщо масив не відсортований, виводимо повідомлення.
        }
    }

    // Приватний метод для визначення, чи є масив відсортованим.
    private static bool IsSortedResult(int[] array)
    {
        for (int i = 1; i < array.Length; i++)  // Перевіряємо кожен елемент, чи він не менший за попередній.
        {
            if (array[i] < array[i - 1])  // Якщо поточний елемент менший за попередній, масив не відсортований.
            {
                return false;  // Повертаємо false.
            }
        }
        return true;  // Якщо перевірка пройшла успішно, масив відсортований.
    }
}