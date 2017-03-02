using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_ChangeGravity : MonoBehaviour {

    public Vector3 Gravity;
	// Use this for initialization
	void Start () {
        Physics.gravity = Gravity;
    }
	

}
