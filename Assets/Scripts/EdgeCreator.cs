using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Adam Drogemuller
public class EdgeCreator : MonoBehaviour {

    public int edgeCount = 0;
    private ArrayList edges = new ArrayList();
    private ArrayList bezierEdges = new ArrayList();
    public Material lineMat;


    public void addEdges(Edge e)
    {
        bool hasEdge = false;
        foreach (Edge edge in edges)
        {
            if (edge.hashCode() == e.hashCode())
            {
                hasEdge = true;
            }
        }
        if (hasEdge == false)
        {
            edges.Add(e);
            edgeCount++;
        }
        // potentially a problem
        edges.Add(e);
        edgeCount++;
    }

    void OnPostRender()
    {
        DrawConnectingLines();
    }

    void DrawConnectingLines()
    {
        //GL.PushMatrix();
        GL.Begin(GL.LINES);
        lineMat.SetPass(0);
        int k = 0;

        foreach (Edge e in edges)
        {
            Color c = e.getColor();
            GL.Color(new Color(c.r, c.g, c.b, 0.8f));
            GL.Vertex3(e.getA().x, e.getA().y, e.getA().z);
            GL.Vertex3(e.getB().x, e.getB().y, e.getB().z);
        }
        GL.End();
        //GL.PopMatrix();
    }

    public bool connected(Edge A, Edge B)
    {
        if (A.getB() == B.getB())
        {
            return true;
        }
        if (A.getA() == B.getA())
        {
            return true;
        }
        if (A.getB() == B.getA())
        {
            return true;
        }
        if (A.getA() == B.getB())
        {
            return true;
        }
        return false;
    }
}
