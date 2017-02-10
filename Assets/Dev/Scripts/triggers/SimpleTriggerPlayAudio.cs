using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudio : SimpleTrigger {

	public AudioSource audi;

    public override void Ping()
    {
		if(!audi.isPlaying)
			audi.Play ();
		this.enabled = false;
    }

}
