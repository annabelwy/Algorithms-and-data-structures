using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    class Graph
    {
        public List<Vertex> allvertexes = new List<Vertex>();
        public List<Edge> alledges = new List<Edge>();
        public int VertexCount => allvertexes.Count;

        public void AddVertex(Vertex vertex)//добавление вершины
        {
            if (!allvertexes.Contains(vertex)) allvertexes.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to, int w = 1)//добавление ребра
        {
            if (allvertexes.Contains(from) && allvertexes.Contains(to))
            {

                Edge edge = new Edge(from, to, w);
                if (!alledges.Contains(edge))//проверка есть ли такое ребро уже, если нет добавляем
                {
                    alledges.Add(edge);
                    from.edges.Add(edge);//связанные ребра с этой вершиной добавляем
                    //to.edges.Add(edge);
                }

            }

        }


        public void RemoveEdge(Vertex from, Vertex to)//удаление ребра по крайним точкам
        {
            if (allvertexes.Contains(from) && allvertexes.Contains(to))
            {

                Edge edge_points = new Edge(from, to);
                foreach (Edge v in alledges)
                {
                    if (v.Equals(edge_points))
                    {
                        Console.WriteLine(1);
                        alledges.Remove(v);
                        from.edges.Remove(v);//связанные ребра с этой вершиной добавляем
                        /*foreach(var e in from.edges)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        Console.WriteLine();*/
                        return;
                    }
                    //to.edges.Add(edge);
                }

            }
        }

        public void RemoveEdge(Edge edge1)//удаление ребра
        {
            foreach (Edge v in alledges)
            {
                if (v.Equals(edge1))
                {
                    Console.WriteLine(1);
                    alledges.Remove(v);
                    edge1.beginVertex.edges.Remove(v);//связанные ребра с этой вершиной добавляем
                    return;
                }
                //to.edges.Add(edge);
            }
        }

        public void ViewEdges()//просмотр ребер
        {
            foreach (Edge v in alledges)
            {
                Console.WriteLine("{0}  ", v.ToString());
            }
            Console.WriteLine();
        }

        public void ViewVertexes()//просмотр вершин
        {
            foreach (Vertex v in allvertexes)
            {
                Console.WriteLine("{0}", v.ToString());
            }
            Console.WriteLine();
        }

        public void ViewColorVertexes()//просмотр цвет вершин в строковом формате 
        {
            foreach (Vertex v in allvertexes)
            {
                Console.WriteLine(v.ToString() + ", " + v.vertexcolor);
            }
            Console.WriteLine();
        }

        public void BFS(Vertex start)//БФС через очередь
        {
            Queue<Vertex> queue = new Queue<Vertex>();//очередь вершин, чтоб вершины записывать
            start.colorVertex = COLORS_VERTEX.GRAY;
            start.d = 0;//кол-во шагов
            Vertex u, v;// начальная, конечные вершины
            List<Edge> u_start;//ребра, в которых u-начальная вершина
            Edge rebro;//ребро чтоб пробежаться п оребрам, в которых u- нач
            queue.Enqueue(start);//поставили в очередь стартовую вершину
            Console.WriteLine("Начинаем обход с {0}", start);
            while (queue.Count > 0)
            {
                u = queue.Dequeue();//извлекаем вершину, которая есть в очереди и присваиваем ее для U
                Console.WriteLine("vertex:" + u);
                u_start = u.edges;//edges - набор связанных ребер, ребра, в которых u-начальная вершина
                for (int i = 0; i < u_start.Count; i++)
                {
                    rebro = u_start[i];
                    v = rebro.endVertex;
                    if (v.colorVertex == COLORS_VERTEX.WHITE)//если WHITE, то можем смотреть
                    {
                        v.colorVertex = COLORS_VERTEX.GRAY;//меняем на серый, тк забежали
                        v.d = u.d + 1;//прибавляем шаг, к тому которые были в вершине, от которой пришли
                        v.prev = u;//ставим предшественника
                        queue.Enqueue(v);//поставили в очередь
                    }
                }
                u.colorVertex = COLORS_VERTEX.BLACK;// больше не заходим

            }
            foreach (Vertex ver in allvertexes)
            {
                ver.colorVertex = COLORS_VERTEX.WHITE;
            }
        }


        public void DFS(Vertex start)//так же как БФС, но вместо очереди - стэк
        {
            Stack<Vertex> stack = new Stack<Vertex>();//стэк
            start.colorVertex = COLORS_VERTEX.GRAY;
            start.d = 0;//кол-во шагов
            Vertex u, v;// начальная, конечные вершины
            List<Edge> u_start;//ребра, в которых u-начальная вершина
            Edge rebro;//ребро чтоб пробежаться п оребрам, в которых u- нач
            stack.Push(start);//кладем вершину на начало
            Console.WriteLine("Начинаем обход с {0}", start);

            //Console.WriteLine("Начинаем обход с {0}", start);
            while (stack.Count > 0)
            {
                u = stack.Pop();//снимает вершину с начала стэка
                Console.WriteLine("vertex:" + u);
                u_start = u.edges;//edges - набор связанных ребер, ребра, в которых u-начальная вершина
                for (int i = 0; i < u_start.Count; i++)
                {
                    //Console.WriteLine("0");
                    rebro = u_start[i];
                    v = rebro.endVertex;
                    if (v.colorVertex == COLORS_VERTEX.WHITE)//если WHITE, то можем смотреть
                    {
                        v.colorVertex = COLORS_VERTEX.GRAY;//меняем на серый, тк забежали
                        v.d = u.d + 1;//прибавляем шаг, к тому которые были в вершине, от которой пришли
                        v.prev = u;//ставим предшественника
                        stack.Push(v);//кладем вершину на начало
                    }
                }
                u.colorVertex = COLORS_VERTEX.BLACK;// больше не заходим

            }
            foreach (Vertex ver in allvertexes)
            {
                ver.colorVertex = COLORS_VERTEX.WHITE;
            }
        }


        public void minOstov()
        {
            //использованные ребра
            List<Edge> UsedE = new List<Edge>();
            //использованные вершины
            List<Vertex> usedV = new List<Vertex>();
            //неиспользованные вершины
            List<Vertex> notUsedV = new List<Vertex>();
            foreach (Vertex v in allvertexes) notUsedV.Add(v);//заполнили неисп
            int minw = int.MaxValue;
            Edge mine = null;
            foreach (Edge e in alledges)
                if (e.w < minw)
                {
                    minw = e.w; mine = e;
                };
            UsedE.Add(mine);
            notUsedV.Remove(mine.beginVertex);
            notUsedV.Remove(mine.endVertex);
            usedV.Add(mine.beginVertex);
            usedV.Add(mine.endVertex);
            while (notUsedV.Count > 0)
            {
                int minweight = int.MaxValue;
                Edge minreb = null;
                foreach (Vertex ver in usedV)
                {
                    foreach (Edge rebrover in ver.edges)
                    {
                        if (notUsedV.Contains(rebrover.endVertex))
                        {
                            if (rebrover.w < minweight)
                            {
                                minweight = rebrover.w;
                                minreb = rebrover;
                            }
                        }
                    }
                }
                Vertex end = minreb.endVertex;
                UsedE.Add(minreb);
                notUsedV.Remove(end);
                usedV.Add(end);
            }
            foreach (Edge e in UsedE)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void raskr()
        {
            //сортируем в порядке убвания степени вершины. Начинаем проходить по отсортированному списку вершин, начинаем закрашивать
            int numbercolor = 0;
            List<Vertex> tmp = new List<Vertex>();
            foreach (Vertex ver in allvertexes)
            {
                ver.vertexcolor = "0";
                tmp.Add(ver);
            }
            int k = 0;
            tmp.Sort((Vertex vertex1, Vertex vertex2) => vertex1.edges.Count.CompareTo(vertex2.edges.Count));//в пор убывания
            while (tmp.Count != k)
            {
                numbercolor++;
                foreach (Vertex vertex in tmp)
                {
                    if (vertex.colorVertex.Equals(COLORS_VERTEX.BLACK))//если вершины прошли, то 
                    {
                        continue;//продолжаем идти дальше
                    }
                    bool check = true;
                    foreach (Edge edge in vertex.edges)
                    {
                        Vertex help;
                        if (vertex.Equals(edge.beginVertex))
                        {
                            help = edge.endVertex;//тк неизвестно считается начальной или конечной
                        }
                        else
                        {
                            help = edge.beginVertex;//если ел -кон, то эта нач
                        }
                        if (help.vertexcolor.Equals(numbercolor.ToString()))//если цвет у второй вершины уже имеет цвет, который мы прошли
                        {
                            check = false;//пропускается окраска в цвет
                            break;
                        }
                    }
                    if (check)
                    {
                        vertex.vertexcolor = numbercolor.ToString();
                        vertex.colorVertex = COLORS_VERTEX.BLACK;
                        k++;
                    }
                }
            }
        }
    }
}