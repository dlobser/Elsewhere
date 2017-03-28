using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudio : SimpleTrigger {

	public AudioSource audi;
	public bool disableAfterPlay = false;

    public override void Ping()
    {
//		if(!audi.isPlaying)
			audi.Play ();
		if(disableAfterPlay)
			this.enabled = false;
    }

}
