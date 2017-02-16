using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAnimation : SimpleTrigger {


    public override void Ping()
    {
		this.GetComponent<Animator> ().SetTrigger ("play");
    }

}
