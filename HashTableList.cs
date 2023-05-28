using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    public class Item<K, T>
    {
        public K key;
        public T value;
        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public K Key
        {
            get { return this.key; }
            set { this.key = value; }
        }
        public override string ToString()
        {
            return string.Format("(key={0},Value={1})", key, value);
        }
     public class HashTableList//хранятся списки, в каждом из которых элементы  с одинаковыми хэш кодами
        {
            public int Size { get; set; }//кол-во списков
            public int Count { get; set; }//общее кол-во

            private List<Item<K, T>>[] lts;//массив списков, каждый список состоит из этих элементов содержит объект Item
            //хэш код тоже позиция в массиве

            public HashTableList(int size)
            {
                this.Size = size;
                this.Count = 0;
                lts = new List<Item<K, T>>[Size];
                for (int i = 0; i < Size; i++)
                {
                    lts[i] = new List<Item<K, T>>();
                }
            }

            public int GetHashIndex(K key)//
            {
                int kk = key.GetHashCode();
                return kk % this.Size;
            }
            public void Add(K key, T value)//точно такой же массив, в котором учитываются хэш коды, когла два эл-та с одинаковыми хэшкодами, они оба будут в одном спсике, который находится в какой-то ячейке массива
                                           ////добавление
            {
                if (Count > 0.8 * Size)//если больше 80 элементов заполнено
                {
                    this.Resize(2);
                }
                Item<K, T> el = new Item<K, T>();
                el.key = key; el.value = value;
                this.lts[this.GetHashIndex(key)].Add(el);
                Count++;
            }

            public void Resize(int n)//новый size, все списки в одном большое, key value из этого массива items, и из большого списка загоняем по набору
            {
                List<Item<K, T>> rabAr = new List<Item<K, T>>();
                for (int i = 0; i < Size; i++)
                {
                    foreach (var el in lts[i])
                    {
                        rabAr.Add(el);
                    }
                }
                Size *= n;
                Count = 0;
                lts = new List<Item<K, T>>[Size];
                for (int i = 0; i < Size; i++)
                {
                    lts[i] = new List<Item<K, T>>();
                }
                foreach (var el in rabAr)
                {
                    this.Add(el.key, el.value);
                }
            }

            public Item<K, T> FindByKey(K key)//поиск по ключу
            {//в массиве ищем список, и в списке просмотраиваем(тут хранятся элементы с одинаковым хэш кодом)
                int kk = this.GetHashIndex(key);
                foreach (var el in lts[kk])//пробегаемся по списку c данных хэш кодом
                {
                    if (el.key.Equals(key))
                    {
                        return el;
                    }
                }
                return null;
            }

            public void RemoveByKey(K key)//удаление по ключу
            {
                int kk = this.GetHashIndex(key);
                Item<K, T> el = FindByKey(key);
                lts[kk].Remove(el);
                Count--;
            }
        }
    }
}
