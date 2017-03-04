using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EW_TweakDate : MonoBehaviour {
	
	[Range(2017,20017)]
	public float date;
	[Range(0,1)]
	public float fade;
	public float poop;
	public TextMesh text;
	Color col;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		col = text.color;
		col.a = fade;
		text.color = col;
		int d = (int)date;
		text.text = d.ToString();
	}
}
