using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudios : SimpleTrigger {

	public AudioSource[] audi;

    public override void Ping()
    {
		bool playing = false;
		for (int i = 0; i < audi.Length; i++) {
			if (audi [i].isPlaying)
				playing = true;
		}
		if(!playing)
			audi[(int)Mathf.Floor(Random.value*audi.Length)].Play ();
		this.enabled = false;
    }

}
