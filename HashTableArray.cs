using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    
    public class Item_nasled<K, T> : Item<K, T>//новый элемент из того
    {
        public bool Used { get; set; }
        public Item_nasled()
        {
            Key = default(K);
            Value = default(T);
            Used = false;
        }
    }
    class HashTableArray<K, T>//массив из элементов, где хэш кодвсе данные в одном массиве
    {
        public int Size { get; set; }
        public int Count { get; set; }
        private Item_nasled<K, T>[] lts;

        public HashTableArray(int size)
        {
            Size = size;
            Count = 0;
            lts = new Item_nasled<K, T>[size];
            for (int i = 0; i < size; i++)
            {
                lts[i] = new Item_nasled<K, T>();
            }
        }

        public int GetHashIndex(K key)
        {
            int kk = key.GetHashCode();
            return kk % this.Size;
        }

        public void Add(K key, T value)//добвление по ключу и значению
        {
            int kk = GetHashIndex(key);// получаем хэш код, берем кей делим на размерность массива
            if (Size == Count)
            {
                Resize(2);
            }
            if (!lts[kk].Used)//есть ли на этом месте элемент какой-то, если не использованое
            {
                lts[kk].Key = key;
                lts[kk].Value = value;
                lts[kk].Used = true;//записываем туда
                Count++;
            }
            else//если есть, запоминаем хэш-код, i используем как счетчик ячеек, начирнаем с той ячейки, на которой остались
            {
                int i = kk;
                while (true)
                {
                    if (i == Size) i = 0;

                    if (!lts[i].Used)
                    {
                        lts[i].Key = key;
                        lts[i].Value = value;
                        lts[i].Used = true;
                        Count++;
                        break;
                    }
                    if (i == kk - 1)//когда нет пустого, но у нас такого не просиходитЮ потому что ресайз
                    {
                        break;
                    }
                    i++;
                }
            }
        }

        public void Resize(int n)//новый size, увеличение в какое-то количество раз и создается новый массив
        {
            Item_nasled<K, T>[] newLts = new Item_nasled<K, T>[Size * n];
            for (int i = 0; i < newLts.Length; i++)
            {
                newLts[i] = new Item_nasled<K, T>();
            }

            Item_nasled<K, T>[] rub = new Item_nasled<K, T>[Count];
            for (int i = 0; i < Count; i++)
            {
                rub[i] = lts[i];
            }
            Count = 0; Size *= n;
            lts = newLts;
            foreach (var el in rub)
            {
                this.Add(el.Key, el.Value);
            }

        }

        public void FindByKey(K key)//чем больше элементов, тем меньше коллизий
        {
            //мы делаем из ключа хэшкод, дальше ищем ячейку
            int hashIndex = GetHashIndex(key);
            if (lts[hashIndex].Key.Equals(key))
            {
                Console.WriteLine(lts[hashIndex].ToString());//нашли ячейку и сравниваем с тем ключом, котоырй в массиве, если совпадает то выводим
            }
            else
            {
                foreach (var el in lts)//по всему массиву
                {
                    if (el.Used && el.Key.Equals(key))
                    {
                        Console.WriteLine(el.ToString());
                        break;
                    }
                }
            }
        }

        public void ViewTable()
        {
            foreach (var el in lts)
            {
                Console.WriteLine(el.ToString());
            }
        }

        public void RemoveByKey(K key)//тот же файнд бу кей, только вместо вывода на экран - обнуляется это место
        {
            int hashIndex = GetHashIndex(key);
            if (lts[hashIndex].Key.Equals(key))
            {
                lts[hashIndex] = new Item_nasled<K, T>();
                Count--;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (lts[i].Used && lts[i].Key.Equals(key))
                    {
                        lts[i] = new Item_nasled<K, T>();
                        Count--;
                        break;
                    }
                }
            }
        }
    }
}
