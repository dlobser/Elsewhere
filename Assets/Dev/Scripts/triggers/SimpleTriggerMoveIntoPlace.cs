using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerMoveIntoPlace : SimpleTrigger {

    Vector3 initialPosition;
    public Vector3 endPosition;
    public float speed;
	// Use this for initialization
	void Start () {
      
	}
    public override void Ping() {
        StartCoroutine(move());
    }
    IEnumerator move() {
        float counter = 0;
        initialPosition = this.transform.localPosition;
        while (counter < speed) {
            counter += Time.deltaTime;
            this.transform.localPosition = Vector3.Lerp(initialPosition, endPosition, Mathf.SmoothStep(0,1, counter / speed));
            yield return null;
        }

    }
 }
