using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder
{
    public class Tree {
        public Graph.Vertex src;
        public Dictionary<Graph.Vertex, float> dist;
        public Dictionary<Graph.Vertex, Graph.Vertex> prev;
    }

    public Tree Dijkstra(Graph g, Graph.Vertex src)
    {
        int srcId = g.GetId(src);;
        Tree tree = new Tree();
        tree.src = src;

        if (srcId == -1)
            return tree;

        List<Graph.Vertex> Q = new List<Graph.Vertex>();

        foreach(Graph.Vertex v in g.vertices)
        {
            tree.dist[v] = Mathf.Infinity;
            tree.prev[v] = null;
            Q.Add(v);
        }
        tree.dist[src] = 0;

        while(Q.Count > 0)
        {
            Graph.Vertex u = null;
            foreach(Graph.Vertex v in g.vertices)
            {
                if(u == null || tree.dist[v] < tree.dist[u])
                    u = v;
            }
            Q.Remove(u);

            foreach(Graph.Vertex v in g.Neighbors(u))
            {
                if(!Q.Contains(u))
                    continue;
                
                float alt = tree.dist[u] + g.GetDistance(u, v);
                if (alt < tree.dist[v])
                {
                    tree.dist[v] = alt;
                    tree.prev[v] = u;
                }
            }
        }

        return tree;
    }

    public List<Graph.Vertex> Pathfind(Graph g, Graph.Vertex src, Graph.Vertex dst)
    {
        Tree t = Dijkstra(g, src);
        return this.Pathfind(g, t, dst);
    }

    public List<Graph.Vertex> Pathfind(Graph g, Tree t, Graph.Vertex dst)
    {
        List<Graph.Vertex> S = new List<Graph.Vertex>();
        Graph.Vertex u = dst;
        
        if (!dst.isWalkable)
        {
            return null;
        }

        if(t.prev[u] == null && u != t.src)
            return S;

        while(u != null)
        {
            S.Insert(0, u);
            u = t.prev[u];
        }

        return S;
    }
}
