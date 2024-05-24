namespace KursovaTPO.ArrayTools;

// Клас для генерації масивів з випадковими числами.
public static class ArrayGenerator
{
    // Статичний екземпляр класу Random для використання у всіх методах.
    private static readonly Random random = new Random();

    // Генерує масив заданого розміру з випадковими числами від 0 до 100000.
    public static int[] GenerateArray(int size)
    {
        int[] array = new int[size]; // Ініціалізація масиву з заданим розміром.

        // Заповнення масиву випадковими числами.
        for (int i = 0; i < size; i++)
        {
            // Кожен елемент масиву отримує випадкове значення від 0 до 100000.
            array[i] = random.Next(0, 100001);
        }

        return array; // Повернення заповненого масиву.
    }
}