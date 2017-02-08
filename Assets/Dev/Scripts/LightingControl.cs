using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightingControl : MonoBehaviour {

	public Color ColorR;
	public Color ColorG;
	public Color ColorB;

	public Material roomMat;
	public Material crystalR;
	public Material crystalG;
	public Material crystalB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		roomMat.SetColor ("_ColorR", ColorR);
		roomMat.SetColor ("_ColorG", ColorG);
		roomMat.SetColor ("_ColorB", ColorB);
		crystalR.color = ColorR;
		crystalG.color = ColorG;
		crystalB.color = ColorB;

	}
}
