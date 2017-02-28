using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class ON_MakeGraph : MonoBehaviour {

    List<ON_Node> nodes;
    public Mesh mesh;
    Mesh weldedMesh;
    public ON_Node node;
    public GameObject GraphParent;

	public bool exportMesh;
    public bool weld = false;

	public bool finishedBuilding { get; set; }
    /*
     * create one node for each vertex
     * loop through all faces
     * add neighbor vertices after checking to see if they have already been added
     * each nodes neighbors are index for checking and reference to actual node
     * */

	void Start () {
		finishedBuilding = false;
        nodes = new List<ON_Node>();
        if(!weld)
            weldedMesh = mesh;// Weld.CopyMesh(mesh);
        else
            weldedMesh = Weld.CopyMesh(mesh);

        //AssetDatabase.CreateAsset(weldedMesh, "Assets/myMesh.mesh" );
        //AssetDatabase.SaveAssets();

        Weld.AutoWeld(weldedMesh, .0000001f, 15f);
        if (GraphParent == null)
            GraphParent = this.gameObject;
        //        BuildGraph();
        StartCoroutine(instanceNodes());
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].Animate();
        }
	}

	IEnumerator instanceNodes(){
		for (int i = 0; i < weldedMesh.vertices.Length; i++)
		{
			nodes.Add(Instantiate(node));
			nodes[i].transform.parent = GraphParent.transform;
			nodes[i].transform.localPosition = Vector3.zero;
			nodes[i].Init(weldedMesh.vertices[i]);
			nodes[i].gameObject.name = "Node_" + i;
			nodes [i].id = i;
			yield return null;

		}
		StartCoroutine (addNeighbors ());
		yield return null;
	}

	IEnumerator addNeighbors(){
		for (int i = 0; i < weldedMesh.triangles.Length; i+=3)
		{
			nodes[weldedMesh.triangles[i]].AddSibling(nodes, weldedMesh.triangles[i + 1]);
			nodes[weldedMesh.triangles[i]].AddSibling(nodes, weldedMesh.triangles[i + 2]);
			nodes[weldedMesh.triangles[i + 1]].AddSibling(nodes, weldedMesh.triangles[i]);
			nodes[weldedMesh.triangles[i + 1]].AddSibling(nodes, weldedMesh.triangles[i + 2]);
			nodes[weldedMesh.triangles[i + 2]].AddSibling(nodes, weldedMesh.triangles[i]);
			nodes[weldedMesh.triangles[i + 2]].AddSibling(nodes, weldedMesh.triangles[i + 1]);
			yield return null;
		}
		finishedBuilding = true;
		yield return null;
	}

    void BuildGraph()
    {
    
        for (int i = 0; i < weldedMesh.vertices.Length; i++)
        {
            nodes.Add(Instantiate(node));
            nodes[i].transform.parent = GraphParent.transform;
            nodes[i].transform.localPosition = Vector3.zero;
            nodes[i].Init(weldedMesh.vertices[i]);
            nodes[i].gameObject.name = "Node_" + i;
           
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

	public List<ON_Node> GetNodeList(){
		return nodes;
	}
}
