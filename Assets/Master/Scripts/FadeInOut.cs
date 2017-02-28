using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {

	public CanvasGroup canvas;
	public Texture fadeTexture;
	public float fadeSpeed = 1;
	float fadeCount = 1;
	public bool fade;
	public bool inOut = false;
	bool prevInOut = true;

	public int fadeCounter { get; set;}
	// Use this for initialization
	void Start () {
		fadeCounter = 0;
	}

	void Update(){
		if (fade != prevInOut) {
			StartCoroutine (Fade ());
		}
		prevInOut = fade;
	}

	IEnumerator Fade (){
		if (inOut) {
			while (fadeCount < 1) {
				fadeCount += Time.deltaTime * fadeSpeed;
				canvas.alpha = fadeCount;
				AudioListener.volume = 1-fadeCount;
				yield return new WaitForSeconds (Time.deltaTime);
			}
			fadeCounter++;
			inOut = false;
		} else {
			while (fadeCount > 0) {
				fadeCount -= Time.deltaTime * fadeSpeed;
				canvas.alpha = fadeCount;
				AudioListener.volume = 1-fadeCount;

				yield return new WaitForSeconds (Time.deltaTime);
			}
			inOut = true;
		}

	}

	
	// Update is called once per frame
//	void OnGui () {
//		float alph = 1;
////		GUI.color.a = alph;
//		GUI.depth = 1000;
//		Debug.Log (GUI.color.a);
//		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
//	}
}

/*
  var fadeTexture : Texture2D;
 var fadeSpeed = 0.2;
 var drawDepth = -1000;
 
 private var alpha = 1.0; 
 private var fadeDir = -1;
 
 function OnGUI(){
     
     alpha += fadeDir * fadeSpeed * Time.deltaTime;  
     alpha = Mathf.Clamp01(alpha);   
     
     GUI.color.a = alpha;
     
     GUI.depth = drawDepth;
     
     GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeTexture);
 }
 */