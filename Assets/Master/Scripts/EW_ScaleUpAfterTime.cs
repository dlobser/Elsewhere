using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_ScaleUpAfterTime : MonoBehaviour {

	public Vector3 startScale;
	public Vector3 endScale;
	public float scaleTime;
	public float startTime;
	Vector3 scale;
	bool started = false;
	// Use this for initialization
	void Start () {
		scale = startScale;
		this.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime && !started) {
			StartCoroutine (scaleUp ());
			started = true;
		}
	}

	IEnumerator scaleUp(){
		float counter = 0;
		while (counter < scaleTime) {
			counter += Time.deltaTime;
			this.transform.localScale = Vector3.Lerp (startScale, endScale, counter / scaleTime);
			yield return new WaitForSeconds (Time.deltaTime);
		}

	}
}
