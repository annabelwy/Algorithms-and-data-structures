using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD
{
    class Edge
    {
        public Vertex beginVertex;
        public Vertex endVertex;

        public int w;

        public Edge()
        {

        }

        public Edge(Vertex begin, Vertex end, int w = 1)
        {
            this.beginVertex = begin;
            this.endVertex = end;
            this.w = w;
        }
        public override string ToString()
        {
            string rebro = "";
            rebro = string.Format("{0} => {1} ={2}", beginVertex, endVertex, w);
            return rebro;
        }

        public bool Equals(Edge edge1)
        {
            if (this.beginVertex.Equals(edge1.beginVertex) && this.endVertex.Equals(edge1.endVertex) && this.w == edge1.w) return true;//то что равны
            return false;
        }
    }
}
