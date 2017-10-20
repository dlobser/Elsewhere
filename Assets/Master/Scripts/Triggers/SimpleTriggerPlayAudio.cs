using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerPlayAudio : SimpleTrigger {

	public AudioSource audi;
	public bool disableAfterPlay = false;
    public bool randomizePitch = false;

    public override void Ping()
    {
        if (audi == null)
            audi = GetComponent<AudioSource>();
        if (randomizePitch)
            audi.pitch = Random.Range(audi.pitch-.2f,audi.pitch+ .2f);
        //		if(!audi.isPlaying)
        audi.Play ();
		if(disableAfterPlay)
			this.enabled = false;
    }

}
