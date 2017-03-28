using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EW_TweakDate : MonoBehaviour {
	
	[Range(2017,20017)]
	public float date;
	[Range(0,1)]
	public float fade;
    public AudioSource audi;
	public TextMesh text;
	Color col;
    int prevD;
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
        if (d != prevD)
            audi.Play();
        prevD = d;
	}
}
