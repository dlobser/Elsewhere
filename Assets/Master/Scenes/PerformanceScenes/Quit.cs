﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.B)) {
            Application.Quit();
            Debug.Log("p");
        }
	}
}