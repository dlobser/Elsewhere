using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EW_FadeAudioToSpriteAlpha : MonoBehaviour {

    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        AudioListener.volume = 1f-image.color.a;
    }
}
