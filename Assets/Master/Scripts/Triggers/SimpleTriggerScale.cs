using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerScale : SimpleTrigger {

    public Vector3 scalar;
    public float speed = 1;
    public float delay = 1;
    Vector3 init;
    void Start() {
        init = this.transform.localScale;
    }
    public override void Ping() {
        StartCoroutine(scale());
        Debug.Log("ping");
    }

    IEnumerator scale() {
        float count = 0;
        while (count < speed) {
            count += Time.deltaTime;
            this.transform.localScale = Vector3.Lerp(init, scalar, count / speed);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(rescale());

    }
    IEnumerator rescale() {

        yield return new WaitForSeconds(delay);
        float count = 0;
        while (count < speed) {
            count += Time.deltaTime;
            this.transform.localScale = Vector3.Lerp(scalar,init, count / speed);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
 }
