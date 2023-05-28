using System;


namespace AiSD
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = { "A", "B", "C", "D" };
            string[] array2 = { "B", "C" };
            Set<String> set1 = new Set<String>(array1);
            Set<String> set2 = new Set<String>(array2);
            set1.ViewSet();
            set2.ViewSet();
            Console.WriteLine("Индекс элемента A в первом множестве:" + set1.GetIndex("A"));
            Console.WriteLine("Существование элемента А во втором множестве:" + set2.Exists("A"));
            set1.RemoveByIndex(1);
            Console.WriteLine("Удаление второго элемента в множестве один: " + set1.ToString());
            Set<String> set3 = new Set<String>();
            //set3.Union(set1, set2);
            //Console.WriteLine("Объединение" + set3.ToString());

            sorts example = new sorts();

            int[] massiv = { 9, 5, 3, 7, 1 };
            int[] mas = { 10, 20, 30, 50, 60, 80, 110, 130, 140, 170 };
            int[] mass = { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            example.MaxSelect<int>(massiv);
            example.BubbleSort<int>(massiv);
            example.Insertionsort<int>(massiv);
            example.Binarysearch<int>(mas, 110);//6
            int[] masss = example.Quick_Sort<int>(mass, 0, mass.Length - 1);
            for (int i = 0; i < masss.Length; i++)
            {
                Console.Write(masss[i] + " ");
            }
            Console.WriteLine();
            example.CountingSort(massiv);
            example.ShellSort(massiv);
            int[] massss = example.mergesort(massiv, 0, massiv.Length - 1);
            for (int i = 0; i < massss.Length; i++)
            {
                Console.Write(massss[i] + " ");
            }
            Console.WriteLine();

            //HashTableList<int, int> hashTable = new HashTableList<int, int>(7);
            //Console.WriteLine("size {0}", hashTable.Size);
            //hashTable.Add(138, 138);
            //hashTable.Add(1, 1);
            //hashTable.Add(45, 242);
            //Console.WriteLine("size {0}",hashTable.Size);
            //hashTable.Add(4535, 242);
            //hashTable.Add(45455, 253542);
            //hashTable.Add(4535, 23242);
            //hashTable.Add(432425, 24223);
            //hashTable.Add(4425, 22442);
            //hashTable.Add(4421235, 1222442);
            //hashTable.Add(5, 5);
            //Console.WriteLine("size {0}", hashTable.Size);
            //hashTable.ViewTable();
            //Console.WriteLine(hashTable.FindByKey(5).ToString());
            //hashTable.RemoveByKey(5);
            //hashTable.ViewTable();
            //Console.WriteLine("Count {0}",hashTable.Count);

            HashTableArray<int, int> hashTable = new HashTableArray<int, int>(5);
            hashTable.Add(10, 10);
            hashTable.Add(5, 10);
            hashTable.Add(7, 10);
            hashTable.ViewTable();
            hashTable.FindByKey(7);

            BinaryTree<Int16> tree = new BinaryTree<Int16>();
            tree.AddNode(20, 32);
            tree.AddNode(10, 64);
            tree.AddNode(15, 15);
            tree.AddNode(30, 72);
            tree.AddNode(6, 50);
            tree.AddNode(55, 37);
            tree.AddNode(57, 58);
            tree.AddNode(8, 69);
            //tree.AddNode(55, 49);
            //BinaryNode<int> tmp = new BinaryNode<int>();
            //tree.FindByKey(8);
            Console.WriteLine(tree.LevelNode(tree.root.Left));
            tree.ViewB(tree.root);
            Console.WriteLine();
            Console.WriteLine((tree.FindByKey(8)).ToString());
            Console.WriteLine(tree.LevelNode(tree.FindByKey(15)));
            Console.WriteLine(tree.MinNode(tree.root));
            Console.WriteLine(tree.MaxNode(tree.root));
            //tree.DeleteNode(20);
            //tree.ViewG(tree.root);
            //Удалим корень
            //tree.remove(33);
            //tree.remove(17);
            Console.WriteLine();
            tree.LeftRotate((tree.root));
            tree.ViewF(tree.root);
            Console.ReadKey();

            Graph graph = new Graph();
            Vertex v1 = new Vertex("one");
            Vertex v2 = new Vertex("two");

            Vertex v3 = new Vertex("three");
            Vertex v4 = new Vertex("for");
            Vertex v5 = new Vertex("five");
            Vertex v6 = new Vertex("six");
            Vertex v7 = new Vertex("seven");
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddEdge(v1, v2, 5);
            graph.AddEdge(v2, v1, 5);
            graph.AddEdge(v1, v4, 3);
            graph.AddEdge(v4, v1, 3);
            graph.AddEdge(v2, v3, 2);
            graph.AddEdge(v3, v2, 2);
            graph.AddEdge(v2, v4, 8);
            graph.AddEdge(v4, v2, 8);
            graph.AddEdge(v3, v4, 6);
            graph.AddEdge(v4, v3, 6);
            graph.AddEdge(v4, v5, 5);
            graph.AddEdge(v5, v4, 5);
            graph.AddEdge(v4, v7, 1);
            graph.AddEdge(v7, v4, 1);
            graph.AddEdge(v3, v7, 6);
            graph.AddEdge(v7, v3, 6);
            graph.AddEdge(v7, v6, 7);
            graph.AddEdge(v6, v7, 7);


            Console.WriteLine("BFS");
            graph.BFS(v1);
            Console.WriteLine("DFS");
            graph.DFS(v1);
            //graph.ViewVertexes();

            //graph.DFS();
            //graph.ViewVertexes();

            graph.minOstov();

            graph.raskr();
            graph.ViewColorVertexes();
        }
    }
}
