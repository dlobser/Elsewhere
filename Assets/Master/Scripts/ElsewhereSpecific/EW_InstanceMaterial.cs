using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_InstanceMaterial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Material mat = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material = mat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
