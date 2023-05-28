using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    public enum COLORS_VERTEX
    {
        WHITE,
        GRAY,
        BLACK
    }
    class Vertex
    {
        public static int ID = 0;
        public int IDVertex;
        public string Name;
        public COLORS_VERTEX colorVertex;
        public List<Edge> edges; //набор связанных ребер
        public int d;//кол-во шагов
        public Vertex prev;
        public string vertexcolor; //запоминание цвета у вершины в раскраске

        public Vertex()
        {
            Name = "NoName";
            edges = new List<Edge>();//набор связанных ребер
            colorVertex = COLORS_VERTEX.WHITE;
            ID++;
            IDVertex = ID;
        }

        public Vertex(string name)
        {
            Name = name;
            edges = new List<Edge>();
            ID++;
            IDVertex = ID;
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", IDVertex, Name, d);
        }

        public void View()
        {
            Console.WriteLine(Convert.ToString(this.IDVertex), this.colorVertex, this.Name);
            foreach (var v in edges)
            {
                Console.WriteLine(v.ToString());
            }
        }
        public bool Equals(Vertex vertex1)
        {
            if (this.Name == vertex1.Name && this.IDVertex == vertex1.IDVertex && this.d == vertex1.d) return true;//то что равны
            return false;
        }


    }
}
