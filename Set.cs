using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    class Set<T> where T : IComparable
    {
        public int size;
        public T[] data;
        public int count;

        public Set()
        {

        }
        public Set(int size)
        {
            this.size = size;
            if (size > 0)
            {
                data = new T[size];
                for (int i = 0; i < size; i++)
                {
                    data[i] = default(T);
                }
                count = 0;
            }
        }

        public Set(T[] arr)
        {
            this.size = arr.Length;
            data = new T[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = arr[i];
            }
            this.count = this.size;
        }

        public int GetIndex(T Value)//просматривает множество, находит элемент, возвращает его индекс
        {
            for (int i = 0; i < count; i++)//идем только по заполненным
            {
                if (data[i].CompareTo(Value) == 0) return i;
            }
            return -1;
        }

        public T GetElement(int index)//просматривает множество, находит элемент под данным индексом, возвращает элемент
        {
            if (count <= index) return default(T);
            return data[index];
        }

        public bool Exists(T Value)//если элемент находится -true, не находится - false
        {
            int element = GetIndex(Value);
            if (element == -1) return false;
            else return true;
        }

        public bool Add(T Value)//добавить новый элемент, если Value не сущ, изменяем размер arr и добавляем, тут сделать bool
        {
            bool b = Exists(Value); if (b)
            {
                Console.WriteLine("Такой элемент уже есть");
                return false;
            }
            if (count < size) { data[count] = Value; count++; return true; }//data[count] добавляется в самое последнее место

            T[] arr = new T[size];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = data[i];

            data = new T[2 * size];
            for (int i = 0; i < arr.Length; i++)
                data[i] = arr[i];
            data[count] = Value; count++; size = data.Length;
            return true;
            //else Console.WriteLine("Элемент уже существует");
        }
        public bool RemoveByValue(T Value)//тут тоже bool, удаляется-истина 
        {
            bool check = Exists(Value);
            if (check == true)
            {
                int index = GetIndex(Value);
                RemoveByIndex(index);
                return true;
            }
            return false;
        }

        public bool RemoveByIndex(int index)//удаляет по индексу
        {
            if (index > (count - 1) || index < 0) { Console.WriteLine("индекс выходит за массив"); return false; }
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < count - 1; j++)
                        data[j] = data[j + 1];//на третье место ставлю 4
                    count--;//мы уменьшаем на 1, тк удалили один элемент
                    data[count] = default;
                }
            }
            return true;
        }

        public void ViewSet()//выводим элементы множества в консоль
        {
            if (count == 0) return;
            Console.Write("{");
            for (int i = 0; i < count - 1; i++)
                Console.Write(data[i] + "; ");
            Console.WriteLine(data[count - 1] + "} ");
        }

        public override string ToString()//создаётся строка со всеми элементами массива
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                result += Convert.ToString(data[i]) + ";";//создаётся строка со всеми элементами массива
            }
            return result;
        }

        public Set<T> Union(Set<T> A, Set<T> B)//объединение, но учитывать элементы множества могут совпадать
        {
            Set<T> C = new Set<T>(A.count + B.count);
            data = new T[A.count + B.count];
            for (int i = 0; i < A.count; i++)
            {
                C.Add(A.GetElement(i));
            }
            for (int i = 0; i < B.count; i++)
            {
                C.Add(B.GetElement(i));
            }
            return C;
        }

        public Set<T> Intersection(Set<T> A, Set<T> B)//пересечение
        {
            Set<T> C = new Set<T>(A.count + B.count);
            for (int i = 0; i < A.count; i++)
            {
                if (B.Exists(A.GetElement(i))) C.Add(A.GetElement(i));
            }
            return C;
        }

        public Set<T> Addition(Set<T> A, Set<T> B)//дополнение
        {
            Set<T> C = new Set<T>(B.count);
            for (int i = 0; i < B.count; i++)
            {
                if (!A.Exists(B.GetElement(i)))//если элемент B не существует в А, то добавляем
                    C.Add(B.GetElement(i));
            }
            return C;
        }

        public List<Set<T>> Podmn()//множество подможеств
        {
            List<Set<T>> LL = new List<Set<T>>();
            int i = 1;
            int max = (int)Math.Pow(2, size);
            string binary;
            while (i<max)
            {
                Set<T> L = new Set<T>(this.size);
                binary = Convert.ToString(i, 2);
                for (int j=binary.Length-1; j >= 0; j-- )
                {
                    if (binary[j] == '1')
                    {
                        L.Add(this.data[binary.Length - 1 - j]);
                    }
                }
                LL.Add(L);
                i++;
            }
            return LL;
        }
    }
}
