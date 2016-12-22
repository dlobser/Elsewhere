using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomAudio : MonoBehaviour {

    public AudioClip[] clips;
    public bool chooseOnPlay;

    private void Awake()
    {
        if (chooseOnPlay)
        {
            Choose();
            this.GetComponent<AudioSource>().Play();
        }
    }

	public void Choose () {
        int rando = (int)Random.Range(0, clips.Length);
        this.GetComponent<AudioSource>().clip = clips[rando];
	}
	
}
