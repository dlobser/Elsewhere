using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EW_SwitchScenesOnFadeOut : MonoBehaviour {

	public FadeInOut fader;
	public int nextScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fader.fadeCounter > 0 && !fader.inOut) {
			SceneManager.LoadScene (nextScene);
		}
	}
}
