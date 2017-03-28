using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAnimation : SimpleTrigger {

//	public bool isPlaying = false;
//	ResetAnimationFromFrustrum reset;

	void Start(){
//		reset = GetComponent<ResetAnimationFromFrustrum> ();
	}

    public override void Ping()
    {
//		if (!this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Moonsplosion") && !isPlaying) {
			this.GetComponent<Animator> ().SetTrigger ("play");
//			isPlaying = true;
//			reset.isUnplayed = false;
//		}
    }

}
