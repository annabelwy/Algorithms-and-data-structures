using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    class NodeList<T>
    {
        public int Key;
        public T Value;
        public NodeList<T> Next;


        public NodeList()
        {
            Key = 0;
            Value = default(T);
            Next = null;
        }

        public NodeList(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Key, Value);
        }
    }

    class SingleList<T> where T : IComparable
    {
        NodeList<T> top;//вершина списка
        public int count;//кол-во узлов в этом списке

        public SingleList()
        {
            top = null;
            count = 0;
        }

        public void AddTop(int key, T value)//добавляем новый узел в начало через ключ и значение
        {
            NodeList<T> tmp = new NodeList<T>(key, value);
            tmp.Next = top;
            top = tmp;
            count++;
        }

        public void AddEnd(int key, T value)//добавляем новый узел в конец через ключ и значение
        {
            if (top == null || count == 0)
            {
                AddTop(key, value);
                count = 1;
                return;//чтоб вышло из метода
            }

            NodeList<T> cur = top;
            NodeList<T> tmp = new NodeList<T>(key, value);
            while (cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = tmp;
            count++;
        }

        public void View()//вывод
        {
            NodeList<T> cur = top;
            Console.WriteLine("SingleList  ");
            while (cur != null)
            {
                Console.WriteLine("{0}->", cur);
                cur = cur.Next;
            }
            Console.WriteLine();
        }

        public void InsertAfter(int keysearch, int key, T value)//вставляем новый узел, который создаем из key и value, после элемента с ключом keysearch
        {
            NodeList<T> cur = top;
            while (cur.Key != keysearch && cur.Next != null)
            {
                cur = cur.Next;
            }
            if (cur.Key == keysearch)
            {
                NodeList<T> tmp = new NodeList<T>(key, value);
                tmp.Next = cur.Next;
                cur.Next = tmp;
                count++;
                return;
            }
            else
            {
                AddEnd(key, value);
                count++;
                return;
            }
        }

        public void InsertBefore(int keysearch, int key, T value)//вставляем новый узел, который создаем из key и value, перед элементом с ключом keysearch
        {
            {
                NodeList<T> cur = top;

                if (cur == null) { AddTop(key, value); return; }
                while (cur.Next.Key != keysearch && cur.Next.Next != null)
                {
                    cur = cur.Next;

                }
                if (cur.Next.Key == keysearch)
                {
                    NodeList<T> tmp = new NodeList<T>(key, value);
                    tmp.Next = cur.Next;
                    cur.Next = tmp;
                    count++;
                    return;
                }
                else
                {
                    AddEnd(key, value);
                    count++;
                    return;
                }

            }
        }

            public void RemoveTop()//удаляем начало списка
            {
                if (top != null)
                {
                    top = top.Next;
                    count--;
                }
            }

            public void RemoveEnd()//удаляем конец списка
        {
                if (count == 1) top = null;
                NodeList<T> cur = top;
                while (cur.Next.Next != null)
                {
                    cur = cur.Next;
                }
                cur.Next = null;
                count--;
            }

            public NodeList<T> FindNodeListByKey(int keysearch)//ищем узел по ключу, возвращаем этот узел
            {
                NodeList<T> cur = top;
                while (cur.Key != keysearch && cur.Next != null)
                {
                    cur = cur.Next;
                }
                if (cur.Key == keysearch)
                {
                    return cur;
                }
                else
                {
                    return null;
                }
            }

            public void RemoveByKey(int keysearch)//удаление по ключу
            {
                NodeList<T> cur = top;
                if (keysearch == top.Key) RemoveTop();
                else
                {
                    while (cur.Next.Key != keysearch && cur.Next.Next == null)
                    {
                        cur = cur.Next;
                    }
                    if (cur.Next.Next == null) { RemoveEnd(); count--; return; }
                    if (cur.Next.Key == keysearch)
                    {
                        cur.Next = cur.Next.Next;
                        count--;
                        return;
                    }
                }
            }
        }
    }

