using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAnimation : SimpleTrigger {


    public override void Ping()
    {
		Debug.Log ("play");
		this.GetComponent<Animator> ().SetTrigger ("play");
    }

}
