using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudios : SimpleTrigger {

	public AudioSource[] audi;
	public bool disableAfterPlay = false;
	public bool randomizePitch = false;

    public override void Ping()
    {
//		bool playing = false;
//		for (int i = 0; i < audi.Length; i++) {
//			if (audi [i].isPlaying)
//				playing = true;
//		}
//		if(!playing)
		int index = (int)Mathf.Floor(Random.value*audi.Length);
		if(randomizePitch)
			audi [index].pitch = Random.Range (.8f, 1.2f);
		audi[index].Play ();
		if(disableAfterPlay)
			this.enabled = false;
    }

}
