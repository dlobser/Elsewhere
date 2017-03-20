using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerMoveUp : SimpleTrigger {

    public Vector3 move;
	// Use this for initialization
	void Start () {
		
	}

    public override void Ping() {
        this.transform.Translate(move.x, move.y, move.z);
    }

}
