using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_FadeInAudio : MonoBehaviour {

    public float fadeSpeed = 1;
    float fadeCount = 0;

    void Start() {
        StartCoroutine(Fade());
    }
    

    IEnumerator Fade() {
        while (fadeCount < fadeSpeed) {
            fadeCount += Time.deltaTime;
            AudioListener.volume = fadeCount / fadeSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
