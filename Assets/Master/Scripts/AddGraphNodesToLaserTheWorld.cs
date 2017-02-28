using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGraphNodesToLaserTheWorld : MonoBehaviour {

	public ON_MakeGraph graph;
	public LaserTheWorld laser;
	// Use this for initialization
	void Start () {
		StartCoroutine (checkForFinished ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator checkForFinished(){
		//Debug.Log (graph.finishedBuilding);
		while (!graph.finishedBuilding) {
			yield return null;
		}
		List<ON_Node> nodes = graph.GetNodeList ();
		for (int i = 0; i < nodes.Count; i++) {
			laser.AddToSource (nodes [i].gameObject);
		}
	}
}
