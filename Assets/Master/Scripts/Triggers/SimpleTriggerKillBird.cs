using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flock;

public class SimpleTriggerKillBird : SimpleTrigger {

    FlockBoid_Simple flock;
    Rigidbody body;
	// Use this for initialization
	void Start () {
        flock = GetComponent<FlockBoid_Simple>();
        body = GetComponent<Rigidbody>();
        
	}
    public override void Ping() {
        Destroy(flock);
        body.isKinematic = false;
    }
}
