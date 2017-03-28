using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmAudioVolume : TriggerPrewarm
{

    public AudioSource audi;

    public float minVolume;
    public float maxVolume;

    void Awake() {
        Reset();
    }
   
    public override void Animate(float t)
    {

		audi.volume = Mathf.Lerp(audi.volume, Mathf.Lerp(minVolume, maxVolume, t),.05f);
    }
	public override void Reset()
	{
        audi.volume = minVolume;

	}



}
