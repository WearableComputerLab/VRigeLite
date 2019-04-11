using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge{

    private Transform a;
    private Transform b;
    private Color c;
    private Transform transformRef;
    private Edge bundle = null;
    private bool directed = false;

    public Edge(Transform a, Transform b, bool directed)
    {
        this.a = a;
        this.b = b;
        c = a.GetComponent<Renderer>().material.color;
        this.directed = directed;
    }

    public void setEdge(Transform a, Transform b)
    {
        this.a = a;
        this.b = b;
    }

    public Vector3 getA()
    {
        return a.position;
    }

    public bool isDirected()
    {
        return directed;
    }

    public Vector3 getB()
    {
        return b.position;
    }

    public Transform getTransformA()
    {
        return a;
    }

    public Transform getTransformB()
    {
        return b;
    }

    public float hashCode()
    {
        return a.transform.position.x * b.transform.position.x;
    }

    public void setColor(Color c)
    {
        this.c = c;
    }

    public Color getColor()
    {
        return a.GetComponent<Renderer>().material.color;
    }

    public void setTransformRef(Transform t)
    {
        this.transformRef = t;
    }

    public Transform getTransformRef()
    {
        return transformRef;
    }

    public Vector3 getMiddle()
    {
        return ((getA() + getB()) / 2);

    }

    public void setBundle(Edge bundle)
    {
        this.bundle = bundle;
    }

    public Edge getBundle()
    {
        return bundle;
    }

}
