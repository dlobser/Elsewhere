using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_AudioScales : MonoBehaviour {

    public float low;
    public float high;
    public float speed;
    AudioSource audi;
	// Use this for initialization
	void Start () {
        audi = this.GetComponent<AudioSource>();
        float p = map(Mathf.Sin(Time.time*speed), -1, 1, low, high);
        audi.pitch = p;
	}

    float map(float s, float a1, float a2, float b1, float b2) {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
