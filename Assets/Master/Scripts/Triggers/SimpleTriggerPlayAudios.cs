﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudios : SimpleTrigger {

	public AudioSource[] audi;
	public bool disableAfterPlay = false;
	public bool randomizePitch = false;
    bool playedOnce = false;
    public override void Ping()
    {
        //		bool playing = false;
        //		for (int i = 0; i < audi.Length; i++) {
        //			if (audi [i].isPlaying)
        //				playing = true;
        //		}
        //		if(!playing)
        if (!playedOnce) {
            int index = (int)Mathf.Floor(Random.value * audi.Length);
            if (randomizePitch)
                audi[index].pitch = Random.Range(.8f, 1.2f);
            if(audi[index]!=null)
                audi[index].Play();
        }
        if (disableAfterPlay) {
            this.enabled = false;
            playedOnce = true;
        }
    }

}