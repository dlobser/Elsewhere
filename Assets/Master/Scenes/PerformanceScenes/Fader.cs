using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    public float speed;
    Material[] materials;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
            StartCoroutine(Fade(true));
        if (Input.GetKeyDown(KeyCode.H))
            StartCoroutine(Fade(false));
	}

    IEnumerator Fade(bool inout) {
        float counter = 0;
        MeshRenderer[] mRend = GetComponentsInChildren<MeshRenderer>();
        materials = new Material[mRend.Length];
        for (int i = 0; i < materials.Length; i++) {
            materials[i] = mRend[i].material;
        }
        while (counter < speed) {
            float which = inout ? counter / speed : 1 - (counter / speed);
            for (int i = 0; i < materials.Length; i++) {
                materials[i].SetFloat("_Mult", which);
            }
            counter += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
