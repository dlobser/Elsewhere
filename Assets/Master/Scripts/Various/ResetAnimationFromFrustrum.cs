using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimationFromFrustrum : MonoBehaviour {

	SkinnedMeshRenderer rend;
	Animator anim;
	public bool isUnplayed = false;
//	SimpleTriggerPlayAnimation player;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SkinnedMeshRenderer> ();
		anim = GetComponent<Animator> ();
//		player = GetComponent<SimpleTriggerPlayAnimation> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (rend.isVisible);
		if (!rend.isVisible && !isUnplayed && Time.time>1) {
			anim.SetTrigger ("unplay");
			isUnplayed = true;
//			player.isPlaying = false;
		}
	}
}
