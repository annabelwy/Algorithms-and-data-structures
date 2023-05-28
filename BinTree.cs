using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    class BinaryNode<T>
    {
        public int Key;//ключ
        public T Value;//значение
        public BinaryNode<T> Parrent;//ссылка на родителя
        public BinaryNode<T> Left;//дочерний левый узел
        public BinaryNode<T> Right;//дочерний правый узел

        public BinaryNode()
        {
            Key = 0;
            Value = default;
            Parrent = null;
            Left = null;
            Right = null;
        }

        public BinaryNode(int k, T v)
        {
            Key = k;
            Value = v;
        }

        public override string ToString()
        {
            string ret = string.Format("(Key = {0} Value = {1})", Key, Value);
            if (Parrent != null) ret = ret + string.Format(" Parent key={0}", Parrent.Key);
            if (Left != null) ret = ret + string.Format(" Left key={0}", Left.Key);
            if (Right != null) ret = ret + string.Format(" Right key={0}", Right.Key);
            return ret;
        }
    }

    class BinaryTree<T>
    {
        public BinaryNode<T> root;//корень дерева
        public BinaryTree()
        {
            root = null;
        }

        public void ViewF(BinaryNode<T> tmp)//просмотр в порядке возрастания
        {
            if (tmp == null) return;
            if (tmp.Left != null) ViewF(tmp.Left);
            Console.WriteLine(tmp);
            if (tmp.Right != null) ViewF(tmp.Right);
        }

        public void ViewB(BinaryNode<T> tmp)//просмотр в порядке убывания
        {
            if (tmp == null) return;
            if (tmp.Right != null) ViewB(tmp.Right);
            Console.WriteLine(tmp);
            if (tmp.Left != null) ViewB(tmp.Left);
        }

        public void ViewG(BinaryNode<T> tmp)//просмотр по иерархии
        {
            if (tmp == null) return;
            Console.WriteLine(tmp);
            if (tmp.Left != null) ViewF(tmp.Left);
            if (tmp.Right != null) ViewF(tmp.Right);
        }
        public bool AddNode(int key, T value)//добавление узла по ключу и значению, добавлено -true
        {
            bool ret = true;
            if (root == null)
            {
                BinaryNode<T> tmp = new BinaryNode<T>(key, value);
                root = tmp;
                return ret;
            }
            BinaryNode<T> tmp2 = root;
            while (tmp2 != null)
            {
                if (tmp2.Key == key) return false;
                if (key < tmp2.Key)//идем влево
                {
                    if (tmp2.Left == null)
                    {
                        BinaryNode<T> nn = new BinaryNode<T>(key, value);
                        nn.Parrent = tmp2;
                        tmp2.Left = nn;
                        return true;
                    }
                    else { tmp2 = tmp2.Left; }
                }
                else
                {
                    if (tmp2.Right == null)
                    {
                        BinaryNode<T> nn = new BinaryNode<T>(key, value);
                        nn.Parrent = tmp2;
                        tmp2.Right = nn;
                        return true;
                    }
                    else { tmp2 = tmp2.Right; }
                }
            }
            return ret;
        }


        public BinaryNode<T> FindByKey(int keysearch)//поиск по ключу, возвращает этот узел
        {
            if (root == null)
            {
                return null;
            }
            BinaryNode<T> cur = root;
            while (cur != null)
            {
                if (cur.Key == keysearch) return cur;
                if (keysearch < cur.Key)
                {
                    if (cur.Left == null)
                    {
                        return null;
                    }
                    else { cur = cur.Left; }

                    if (keysearch > cur.Key)
                    {
                        if (cur.Right == null)
                        {
                            return null;
                        }
                        else { cur = cur.Right; }
                    }
                }
            }
            return cur;
        }

        public int LevelNode(BinaryNode<T> tmp)//идем вверх пока возможно
        {
            int level = 0;
            BinaryNode<T> current = tmp;
            while (current.Parrent != null)
            {
                level++;
                current = current.Parrent;
            }
            return level;
        }

        public BinaryNode<T> MinNode(BinaryNode<T> tmp)//поиск минимального узла
        {
            BinaryNode<T> current = tmp;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }


        public BinaryNode<T> MaxNode(BinaryNode<T> tmp)//поиск максимального узла
        {
            BinaryNode<T> current = tmp;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }

        public BinaryNode<T> NextNodeNew(BinaryNode<T> x)//Найти след узел по значению ключа
        {
            if (x.Right != null)
            {
                return MinNode(x.Right);
            }
            BinaryNode<T> y = x.Parrent;
            while (y != null && x == y.Right)
            {
                x = y;
                y = y.Parrent;
            }
            return y;
        }

        public bool DeleteNode(int key)//удаление узла по ключу, все три случая( лист, одно поддерево, два поддерева)
        {
            BinaryNode<T> delnode = FindByKey(key);
            if (delnode == null) return false;
            //если у узла нет подузлов, можно его удалить(лист)
            if (delnode.Left == null & delnode.Right == null)
            {
                //Console.WriteLine("Delete Leaf");
                if (delnode == root) { root = null; return true; }
                if (delnode.Parrent.Right == delnode) { delnode.Parrent.Right = null; return true; }
                if (delnode.Parrent.Left == delnode) { delnode.Parrent.Left = null; return true; }
            }
            //если одно поддерево - либо справа либо слева
            if (delnode.Left == null || delnode.Right == null)
            {
                //Console.WriteLine("Delete with one subtree");
                if (delnode == root)  //Проверка на корень
                {
                    if (root.Left != null) { root = root.Left; }
                    if (root.Right != null) { root = root.Right; }
                    return true;
                }
                BinaryNode<T> p = delnode.Parrent;
                if (delnode.Left == null)
                {
                    if (p.Left == delnode) { p.Left = delnode.Right; return true; }
                    else { p.Right = delnode.Right; }

                    delnode.Right.Parrent = p;
                }
                else
                {
                    if (p.Left == delnode) { p.Left = delnode.Left; return true; }
                    else { p.Right = delnode.Left; }

                    delnode.Left.Parrent = p;
                }
            }

            //если два поддерева
            if (delnode.Left != null && delnode.Right != null)
            {
                BinaryNode<T> children = NextNodeNew(delnode); //потомок
                delnode.Key = children.Key;//меняем ключи, т.е.  ключ удаляемого узла-> ключ потомка
                delnode.Value = children.Value;
                if (children.Parrent.Left == children)
                {
                    children.Parrent.Left = children.Right;
                    if (children.Right != null) { children.Right.Parrent = children.Parrent; return true; }
                    return true;
                }
                else children.Parrent.Right = children.Right;
                if (children.Right != null) { children.Right.Parrent = children.Parrent; return true; }
            }
            return false;
        }

        public void LeftRotate(BinaryNode<T> x)//Алгоритм вращения влево осуществляется в три шага:земенить текущий корень на его правого потомка, переместить левого потомка нового корня на место правого потомка старого корня, присвоить новому корню в качестве правого узла значение старого корня

        {
            if (x.Right != null)
            {
                BinaryNode<T> y = x.Right; //находим у
                x.Right = y.Left;// левое поддерево у становится правым поддеревом х

                if (y.Left != null)
                {
                    y.Parrent.Left = x;
                }
                y.Parrent = x.Parrent;//делаем родителя х родителем y
                if (x.Parrent == null)
                {
                    root = y;
                }
                else if (x == x.Parrent.Left) { x.Parrent.Left = y; }
                else x.Parrent.Right = y;
                y.Left = x;//делаем х левым ребенком у
                x.Parrent = y;
            }
        }

        public void RightRotate(BinaryNode<T> x)//вращение вправо
        {
            if (x.Left != null)
            {
                BinaryNode<T> y = x.Left; //находим у
                x.Left = y.Right;// правое поддерево у становится левым поддеревом х

                if (y.Right != null)
                {
                    y.Parrent.Right = x;
                }
                y.Parrent = x.Parrent;//делаем родителя х родителем y
                if (x.Parrent == null)
                {
                    root = y;
                }
                else if (x == x.Parrent.Right) { x.Parrent.Right = y; }
                else x.Parrent.Left = y;
                y.Right = x;//делаем х правым ребенком у
                x.Parrent = y;
            }
        }
    }
}
