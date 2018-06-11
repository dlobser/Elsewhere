using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardScaleFlare : MonoBehaviour {

    public GameObject flare;
    Vector3 initScale;
    public ParticleSystem parti;
    public float emitRate = 50;
	// Use this for initialization
	void Start () {
        initScale = flare.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.I)) {
            flare.transform.localScale = Vector3.one;
            parti.emissionRate = emitRate;
        }
        else {
            flare.transform.localScale = initScale;
            parti.emissionRate = 0;

        }
    }
}
