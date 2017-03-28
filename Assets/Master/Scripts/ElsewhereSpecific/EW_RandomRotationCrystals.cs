using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_RandomRotationCrystals : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < this.transform.childCount; i++) {
            Transform t = this.transform.GetChild(i);
            float b = ((int)(Random.value * 6)) * 60;
            Debug.Log(b);
            t.Rotate(new Vector3(0, b,0    ));
        }
	}
	
}
