using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EW_SwitchScene : MonoBehaviour {

    public bool sceneSwitch = false;
    public int whichScene;

	// Update is called once per frame
	void Update () {
        if (sceneSwitch) {
            SceneManager.LoadScene(whichScene);
        }
	}
}
