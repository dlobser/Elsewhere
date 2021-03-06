﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitCrystals : MonoBehaviour {

	public float rate;
	public ON_MouseInteraction mouse;
	public GameObject[] crystals;
	float counter = 0;
	public float scaleMin;
	public float scaleMax;
	public GameObject container;
    public bool parentToTarget;
    public Vector3 randomRotation;
    public float crystalDistance = 1;
    public float scaleUpSpeed = 10;
    //public Vector3 max = Vector3.Max;
    //public Vector3 min = Vector3.Min;
	public int maxCrystals;
	int crystalAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (mouse.hitObject != null) {
            if (!mouse.hitPosition.Equals(Vector3.zero) &&
                mouse.hitObject.GetComponent<Crystalizable>() != null &&
                crystalAmount < maxCrystals &&
                Vector3.Distance(mouse.hitPosition, Camera.main.transform.position) > crystalDistance) {
                if (rate > 0 && counter == 0) {
                    float scale = Random.Range(scaleMin, scaleMax);
                    Vector3 scalar = new Vector3(scale, scale, scale);
                    GameObject g;
                    if (mouse.hitObject.GetComponent<Crystalizable>().type == 0)
                        g = Instantiate(crystals[(int)(Random.value * (crystals.Length))]);
                    else
                        g = Instantiate(crystals[mouse.hitObject.GetComponent<Crystalizable>().type-1]);

                    g.transform.position = mouse.hitPosition;
				
//                    g.transform.localEulerAngles = (mouse.hitNormal * Mathf.PI * 2 * 360) + (Vector3.Scale( Random.insideUnitSphere,randomRotation));
                    //g.transform.localScale = scalar;
//                    Debug.Log(g);
					g.transform.LookAt(mouse.hitPosition+mouse.hitNormal);
					g.transform.Rotate((Vector3.Scale( Random.insideUnitSphere,randomRotation)));
						
                    StartCoroutine(scaleUp(scalar, g));
                    if (parentToTarget)
                        g.transform.SetParent(mouse.hitObject.transform);
                    else
                        g.transform.SetParent(container.transform);
                    crystalAmount++;
                }
            }
        }
		counter += Time.deltaTime*rate;

		if (counter > 1)
			counter = 0;
	}

    IEnumerator scaleUp(Vector3 scale, GameObject g) {
        float count = 0;
        g.transform.localScale = Vector3.zero;
        Crystalizable c = g.GetComponent<Crystalizable>();
        if (c != null)
            c.enabled = false;
        while (count < 1) {
            count += Time.deltaTime * scaleUpSpeed;
			if(g!=null)
            	g.transform.localScale = Vector3.Lerp(Vector3.zero, scale, Mathf.SmoothStep(0f,1f, count));
            yield return null;
        }
        if (c != null)
            c.enabled = true;
    }
}
