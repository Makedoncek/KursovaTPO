namespace KursovaTPO.MergeSortAlgorithms;

// Клас для послідовної реалізації алгоритму сортування злиттям
class SequentialMergeSort {

    // Об'єднує два підмасиви arr[]. Перший підмасив це arr[l..m], другий — arr[m+1..r]
    public void Merge(int[] arr, int l, int m, int r)
    {
        // Визначаємо розміри двох підмасивів для злиття
        int n1 = m - l + 1;
        int n2 = r - m;

        // Створюємо тимчасові масиви
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Копіюємо дані до тимчасових масивів
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        // Об'єднуємо тимчасові масиви

        // Початкові індекси першого і другого підмасивів
        i = 0;
        j = 0;

        // Початковий індекс об'єднаного підмасиву
        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Копіюємо решту елементів з L[], якщо вони залишились
        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Копіюємо решту елементів з R[], якщо вони залишились
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Головна функція, що сортує масив arr[l..r] використовуючи merge()
    public void Sort(int[] arr, int l, int r)
    {
        if (l < r) {

            // Знаходимо середню точку
            int m = l + (r - l) / 2;

            // Сортуємо першу та другу половини
            Sort(arr, l, m);
            Sort(arr, m + 1, r);

            // Об'єднуємо відсортовані половини
            Merge(arr, l, m, r);
        }
    }
}