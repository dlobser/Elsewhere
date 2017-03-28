using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAfterChildrenUnrenderable : MonoBehaviour {

	bool ready = false;
	public SimpleTrigger[] simpleTriggers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < this.transform.childCount; i++) {
			if (this.transform.GetChild (i).GetComponent<MeshRenderer> ().enabled)
				ready = true;
		}
		if (!ready) {
			for (int i = 0; i < simpleTriggers.Length; i++) {
				simpleTriggers [i].Ping ();
			}
		}

		ready = false;
	}
}
