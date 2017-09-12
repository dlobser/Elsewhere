using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EW_AdvanceScene : MonoBehaviour {

	int nextScene = 0;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp( KeyCode.R)) {
			SceneManager.LoadScene (0);
			nextScene = 0;
		}
		if (Input.GetKeyUp (KeyCode.N))
		{
			SceneManager.LoadScene (++nextScene);
		}
	}
    
}
