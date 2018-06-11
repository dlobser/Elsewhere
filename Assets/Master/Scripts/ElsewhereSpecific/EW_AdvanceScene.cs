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
        if (Input.GetKeyUp(KeyCode.Alpha0)) {
            if (Input.GetKey(KeyCode.LeftShift))
                SceneManager.LoadScene(10);
            else {
                SceneManager.LoadScene(0);
                nextScene = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            SceneManager.LoadScene(1);
            nextScene = 1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            SceneManager.LoadScene(2);
            nextScene = 2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            SceneManager.LoadScene(3);
            nextScene = 3;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            SceneManager.LoadScene(4);
            nextScene = 4;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5)) {
            SceneManager.LoadScene(5);
            nextScene = 5;
        }
        if (Input.GetKeyUp(KeyCode.Alpha6)) {
            SceneManager.LoadScene(6);
            nextScene = 6;
        }
        if (Input.GetKeyUp(KeyCode.Alpha7)) {
            SceneManager.LoadScene(7);
            nextScene = 7;
        }
        if (Input.GetKeyUp(KeyCode.Alpha8)) {
            SceneManager.LoadScene(8);
            nextScene = 8;
        }
        if (Input.GetKeyUp(KeyCode.Alpha9)) {
            SceneManager.LoadScene(9);
            nextScene = 9;
        }
    }
    
}
