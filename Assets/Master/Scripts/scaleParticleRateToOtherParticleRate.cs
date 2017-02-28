using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleParticleRateToOtherParticleRate : MonoBehaviour {

	public ParticleSystem fromParticle;
//	public ParticleSystem toParticle;
	public EmitCrystals crystals;

	public float multiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rate = fromParticle.emissionRate;
		crystals.rate = rate * multiplier;
//		toParticle.emissionRate = rate * multiplier;

	}
}
