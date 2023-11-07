using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ties : MonoBehaviour
{
    public Area area;
    private Graph graph = new Graph();
    private Pathfinder pathfinder = new Pathfinder();

    void Start()
    {
        if(area == null)
            area = GetComponent<Area>();

        PopulateGraph();
    }

    List<Vector2> GetPathTo(Vector2 src, Vector2 dst)
    {
        List<Graph.Vertex> S = this.GetVertexPathTo(src, dst);
        return S.ConvertAll(v => v.position);
    }

    List<Graph.Vertex> GetVertexPathTo(Vector2 src, Vector2 dst)
    {
        Graph.Vertex vSrc = graph.GetVertex(src);
        Graph.Vertex vDst = graph.GetVertex(dst);

        if(vSrc == null || vDst == null)
            return new List<Graph.Vertex>();

        return this.GetVertexPathTo(vSrc, vDst);
    }

    List<Graph.Vertex> GetVertexPathTo(Graph.Vertex vSrc, Graph.Vertex vDst)
    {
        return pathfinder.Pathfind(graph, vSrc, vDst);
    }

    void PopulateGraph()
    {
        Vector2 nextPos = area.GetNextPos();
        Graph.Vertex newVertex;
        do
        {
            newVertex = new Graph.Vertex(nextPos);
            newVertex.isWalkable = !area.IsObstructed(nextPos);
            graph.AddVertex(newVertex);    
        } while ((nextPos = area.GetNextPos()) != area.GetLowPos());

        foreach(Graph.Vertex v in graph.vertices)
        {
            if(v.position.x > area.GetLowPos().x)
                graph.AddEdge(v, graph.GetVertex(
                    new Vector2(v.position.x - 1, v.position.y)
                ));
            if(v.position.x < area.GetHighPos().x)
                graph.AddEdge(v, graph.GetVertex(
                    new Vector2(v.position.x + 1, v.position.y)
                ));
            if(v.position.y > area.GetLowPos().y)
                graph.AddEdge(v, graph.GetVertex(
                    new Vector2(v.position.x, v.position.y - 1)
                ));
            if(v.position.y < area.GetHighPos().y)
                graph.AddEdge(v, graph.GetVertex(
                    new Vector2(v.position.x, v.position.y + 1)
                ));
        }
    }
}
