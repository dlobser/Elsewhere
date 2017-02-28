using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_ActivateAfterTime : MonoBehaviour {

	public Collider[] colliders;


	public float startTime;
	bool started = false;

	// Update is called once per frame
	void Update () {
		if (Time.time > startTime && !started) {
			for (int i = 0; i < colliders.Length; i++) {
				colliders [i].enabled = true;
			}
			started = true;
		}
	}


}
