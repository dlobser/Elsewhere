using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_LookAtAndScale : MonoBehaviour {

    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt( target.transform.position);
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, 0, this.transform.localEulerAngles.z);
        float scale = Vector3.Distance(this.transform.position, target.transform.position);
        this.transform.localScale = new Vector3(scale, scale, scale);
	}
}
