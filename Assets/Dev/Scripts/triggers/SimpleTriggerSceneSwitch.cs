using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleTriggerSceneSwitch : SimpleTrigger {

    public int nextScene;

    public override void Ping() {
        SceneManager.LoadScene(nextScene);
    }
}
