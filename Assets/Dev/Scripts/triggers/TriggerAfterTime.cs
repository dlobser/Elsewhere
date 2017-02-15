using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAfterTime : MonoBehaviour {

	public float timeToTrigger;
	public float newTime;
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToTrigger) {
			this.GetComponent<Trigger> ().timeToTrigger = newTime;
			this.GetComponent<Trigger> ().Ping ();
		}
	}
}
