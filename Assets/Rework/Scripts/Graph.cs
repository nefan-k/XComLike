using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public class Vertex {

        public bool isWalkable = true;
        public Vector2 position;
        public List<Vertex> edges;

        public Vertex()
        {
            this.position = Vector2.zero;
            this.edges = new List<Vertex>();
        }

        public Vertex(Vector2 pos)
        {
            this.position = pos;
            this.edges = new List<Vertex>();
        }

        public Vertex(Vector2 pos, List<Vertex> edges)
        {
            this.position = pos;
            this.edges = edges;
        }
    }

    public List<Vertex> vertices = new List<Vertex>();

    public bool Adjacent(Vertex u, Vertex v)
    {
        return u.edges.Contains(v) || v.edges.Contains(u);
    }

    public List<Vertex> Neighbors(Vertex u)
    {
        return u.edges;
    }

    public void AddVertex(Vertex u) {
        if (vertices.Contains(u))
            return;
        vertices.Add(u);
    }

    public void RemoveVertex(Vertex u) {
        if (!vertices.Contains(u))
            return;
        vertices.Remove(u);
    }

    public void SetPosition(Vertex u, Vector2 position)
    {
        u.position = position;
    }

    public void AddEdge(Vertex u, Vertex v) {
        if (!u.edges.Contains(v))
            u.edges.Add(v);
        if (!v.edges.Contains(u))
            v.edges.Add(u);
    }

    public void RemoveEdge(Vertex u, Vertex v) {
        if (u.edges.Contains(v))
            u.edges.Remove(v);
        if (u.edges.Contains(u))
            v.edges.Remove(u);
    }

    public int GetId(Vertex u)
    {
        if (!vertices.Contains(u))
            return -1;

        return vertices.IndexOf(u);
    }

    public int GetId(Vector2 position)
    {
        int id = -1;
        for(int i = 0; i < vertices.Count; i++)
            if (vertices[i].position == position)
            {
                id = i;
                break;
            }

        return id;
    }

    public Vertex GetVertex(Vector2 position)
    {
        foreach(Vertex v in vertices)
            if(v.position == position)
                return v;

        return null;
    }

    public float GetDistance(Vertex u, Vertex v)
    {
        return v.isWalkable ? Vector2.Distance(
            u.position,
            v.position
        ) : Mathf.Infinity;
    }
}