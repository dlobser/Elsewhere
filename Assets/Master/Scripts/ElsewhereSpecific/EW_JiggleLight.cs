using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_JiggleLight : MonoBehaviour {

    public float jiggleAmount;
    Color init;
	// Use this for initialization
	void Start () {
        init = GetComponent<Light>().color;
	}
	
	// Update is called once per frame
	void Update () {
        Color col = new Color(
            Random.Range(init.r - jiggleAmount, init.r + jiggleAmount),
            Random.Range(init.g - jiggleAmount, init.g + jiggleAmount),
            Random.Range(init.b - jiggleAmount, init.b + jiggleAmount));
        GetComponent<Light>().color = col;
	}
}
