using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNormal : MonoBehaviour {

	ON_MouseInteraction mouse;
	public GameObject pointer;
	public float mult;
	// Use this for initialization
	void Start () {
		mouse = GetComponent<ON_MouseInteraction> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ON_MouseInteraction.beenHit) {
			pointer.transform.position = mouse.hitPosition;
			Vector3 vec = mouse.hitPosition + ( mouse.hitNormal )  ;
			pointer.transform.LookAt (vec);
//			pointer.transform.localEulerAngles = new Vector3 (vec.x, vec.z, vec.y);
		}
	}
}
