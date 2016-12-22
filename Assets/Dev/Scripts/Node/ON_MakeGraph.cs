﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_MakeGraph : MonoBehaviour {

    List<ON_Node> nodes;
    public Mesh mesh;
    Mesh weldedMesh;
    public ON_Node node;
    public GameObject GraphParent;
	
    /*
     * create one node for each vertex
     * loop through all faces
     * add neighbor vertices after checking to see if they have already been added
     * each nodes neighbors are index for checking and reference to actual node
     * */

	void Start () {
        nodes = new List<ON_Node>();
        weldedMesh = Weld.CopyMesh(mesh);
        Weld.AutoWeld(weldedMesh, .001f, 15f);
        if (GraphParent == null)
            GraphParent = this.gameObject;
        BuildGraph();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].Animate();
        }
	}

    void BuildGraph()
    {
    
        for (int i = 0; i < weldedMesh.vertices.Length; i++)
        {
            nodes.Add(Instantiate(node));
            nodes[i].transform.parent = GraphParent.transform;
            nodes[i].transform.localPosition = Vector3.zero;
            nodes[i].Init(weldedMesh.vertices[i]);
           
        }

        for (int i = 0; i < weldedMesh.triangles.Length; i+=3)
        {
            nodes[weldedMesh.triangles[i]].AddSibling(nodes, weldedMesh.triangles[i + 1]);
            nodes[weldedMesh.triangles[i]].AddSibling(nodes, weldedMesh.triangles[i + 2]);
            nodes[weldedMesh.triangles[i + 1]].AddSibling(nodes, weldedMesh.triangles[i]);
            nodes[weldedMesh.triangles[i + 1]].AddSibling(nodes, weldedMesh.triangles[i + 2]);
            nodes[weldedMesh.triangles[i + 2]].AddSibling(nodes, weldedMesh.triangles[i]);
            nodes[weldedMesh.triangles[i + 2]].AddSibling(nodes, weldedMesh.triangles[i + 1]);
        }
    }
}
