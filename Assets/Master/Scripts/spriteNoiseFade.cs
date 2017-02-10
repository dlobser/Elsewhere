using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteNoiseFade : MonoBehaviour {

	public float amount;
	public float speed;
	SpriteRenderer spRend;
	Color initColor;
	Color newColor;
	float rando;
	// Use this for initialization
	void Start () {
		rando = Random.value*100;
		spRend = GetComponent<SpriteRenderer> ();
		initColor = spRend.color;
		newColor = initColor * amount;
	}
	
	// Update is called once per frame
	void Update () {
		spRend.color = Color.Lerp (initColor, newColor, Mathf.PerlinNoise (rando+Time.time * speed, 0));
	}
}
