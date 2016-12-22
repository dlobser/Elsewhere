using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomAudio : MonoBehaviour {

    public AudioClip[] clips;
	// Use this for initialization
	public void Choose () {
        int rando = (int)Random.Range(0, clips.Length);
        this.GetComponent<AudioSource>().clip = clips[rando];
	}
	
}
