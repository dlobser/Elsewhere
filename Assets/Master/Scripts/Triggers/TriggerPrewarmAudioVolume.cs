using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmAudioVolume : TriggerPrewarm
{

    public AudioSource audi;

    public float minVolume;
    public float maxVolume;

    public bool lerp = true;

    void Awake() {
        Reset();
    }
   
    public override void Animate(float t)
    {
        if (lerp)
            audi.volume = Mathf.Lerp(audi.volume, Mathf.Lerp(minVolume, maxVolume, t), .05f);
        else
            audi.volume = t;
    }
	public override void Reset()
	{
        audi.volume = minVolume;

	}



}
