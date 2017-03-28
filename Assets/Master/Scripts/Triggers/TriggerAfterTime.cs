using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAfterTime : MonoBehaviour {

	public float timeToTrigger;
	public float newTime;
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > timeToTrigger && this.GetComponent<Trigger>().triggerCount < 1) {
            this.GetComponent<Trigger>().timeToTrigger = newTime;
            this.GetComponent<Trigger>().Ping();
        }
        else if (this.GetComponent<Trigger>().triggerCount > 0)
            this.enabled = false;
	}
}
