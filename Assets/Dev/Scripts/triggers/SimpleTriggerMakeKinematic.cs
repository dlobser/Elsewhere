using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerMakeKinematic : SimpleTrigger {

	public float force;

    public override void Ping()
    {
		for (int i = 0; i < this.transform.parent.transform.childCount; i++) {
			this.transform.parent.transform.GetChild(i).GetComponent<Rigidbody> ().isKinematic = false;
		}
//		this.GetComponent<Rigidbody> ().isKinematic = false;
		this.GetComponent<Rigidbody> ().AddForce (Random.insideUnitSphere * force);
    }

}
