using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerMakeKinematic : SimpleTrigger {

	public float force;
    public ON_MouseInteraction mouse;
    public bool makeAllSiblingsKinematic = true;

    public override void Ping() {
        if (makeAllSiblingsKinematic) { 
            for (int i = 0; i < this.transform.parent.transform.childCount; i++) {
                this.transform.parent.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        //		this.GetComponent<Rigidbody> ().isKinematic = false;
        if (mouse != null) {
            if (!mouse.hitPosition.Equals(Vector3.zero)) {
                Vector3 direction = this.transform.position - mouse.hitPosition;
                this.GetComponent<Rigidbody>().AddForce(direction*force);
            }
        }
        else
		    this.GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
    }

}
