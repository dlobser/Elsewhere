using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_PlayAudioAfterTime : MonoBehaviour {

	public float startTime;
	bool played = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!played &&  Time.timeSinceLevelLoad > startTime) {
			this.GetComponent<AudioSource> ().Play ();
			played = true;
		}
	}
}
