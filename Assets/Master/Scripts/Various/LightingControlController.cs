using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingControlController : MonoBehaviour {

	public LightingControl ctrl;

	public Vector3 brightnessSpeed;
    public Vector3 brightness;
    public Vector3 saturation;
	public Vector3 brightnessOffset;

	public Vector3 hueSpeed;

	Vector3 brightnessClock;
	Vector3 hueClock;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		brightnessClock += new Vector3 (
			(Time.deltaTime * brightnessSpeed.x), 
			(Time.deltaTime * brightnessSpeed.y), 
			(Time.deltaTime * brightnessSpeed.z));
		hueClock += new Vector3 (Time.deltaTime * hueSpeed.x, Time.deltaTime * hueSpeed.y, Time.deltaTime * hueSpeed.z);

		ctrl.ColorR = Color.HSVToRGB (Noiser (hueClock.x), saturation.x, brightness.x + Mathf.Pow(Noiser (brightnessOffset.x+brightnessClock.x),2));
		ctrl.ColorG = Color.HSVToRGB (Noiser (hueClock.y), saturation.y, brightness.y + Mathf.Pow(Noiser (brightnessOffset.y+brightnessClock.y),2));
		ctrl.ColorB = Color.HSVToRGB (Noiser (hueClock.z), saturation.z, brightness.z + Mathf.Pow(Noiser (brightnessOffset.z+brightnessClock.z),2));
	}

	float Noiser(float i){
		return Mathf.PerlinNoise (i, i);
	}
}
