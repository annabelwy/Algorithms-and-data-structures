using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class sorts
    {
        public static void printArray<T>(T[] arr) where T : IComparable // в строку
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        public void print_array<T>(T[] arr) where T : IComparable // в столбик
        {
            int i = 0;
            int n = arr.Length;
            while (n > 0)
            {
                Console.WriteLine(arr[i]);
                n--;
                i++;
            }
        }
        public void BubbleSort<T>(T[] arr) where T : IComparable//тяжелые элементы постепенно спускаются вниз
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // swap temp and arr[i]
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            printArray(arr);
        }

        public void Insertionsort<T>(T[] arr) where T : IComparable//перемещаем вперед пока элемент меньше текущего
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && (arr[j].CompareTo(key) > 0))
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            printArray(arr);
        }

        public T[] Quick_Sort<T>(T[] arr, int left, int right) where T : IComparable//длинный массив, выделяем часть массива, патричный разделитель, пока не останется 2
        {

            if (left < right)
            {

                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }

            }
            return arr;
        }

        public static int Partition<T>(T[] arr, int left, int right) where T : IComparable//партичный разделитель
        {
            T pivot = arr[left];
            while (true)
            {

                while (arr[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (arr[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left].CompareTo(arr[right]) == 0) return right;

                    T temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }

        }

        public int Binarysearch<T>(T[] arr, T item) where T : IComparable // T[] arr -сортированный
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                T guess = arr[mid];
                if (guess.CompareTo(item) == 0)
                {
                    //return mid;
                    Console.WriteLine(mid);
                }
                if (guess.CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;

        }

        public void MaxSelect<T>(T[] arr) where T : IComparable//обмениваем, если imax не совпадает с последним
        {
            T maxitem;
            int maxindex;
            int len = arr.Length;
            while (len > 1)
            {
                maxindex = 0;
                maxitem = arr[0];
                for (int i = 1; i < len; i++)
                {
                    if (arr[i].CompareTo(maxitem) > 0)
                    {
                        maxindex = i;
                        maxitem = arr[i];
                    }
                }
                T temp = maxitem;
                arr[maxindex] = arr[len - 1];
                arr[len - 1] = temp;

                len -= 1;
            }
            printArray(arr);
        }

        public void merge<T>(T[] arr, int l, int m, int r) where T : IComparable// Объединяет два подмассива []arr.Первый подмассив - это arr[l..m].Второй подмассив равен arr[m+1..r]
    {
        int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1];
            T[] R = new T[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public T[] mergesort<T>(T[] arr, int l, int r) where T : IComparable
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                mergesort(arr, l, m);
                mergesort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
            return arr;
        }

        public void ShellSort<T>(T[] arr) where T : IComparable//сдвиг делается равный половине массива, после этого сдвиг уменьшаем в два раза, пока сдвиг не станет=1
        {
            int n = arr.Length;
            int i, j, pos;
            T temp;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < n; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= pos) && (arr[j - pos].CompareTo(temp) > 0))
                    {
                        arr[j] = arr[j - pos];
                        j = j - pos;
                    }
                    arr[j] = temp;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
            printArray(arr);
        }
        public void CountingSort(int[] arr)//входные даннык-целые числа, подсчитываем количество элементов определнного значения
        {
            int max = arr.Max();
            int min = arr.Min();
            int range = max - min + 1;
            int[] count = new int[range];
            int[] output = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
            printArray(arr);
        }

    }
