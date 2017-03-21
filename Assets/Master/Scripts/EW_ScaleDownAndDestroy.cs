using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_ScaleDownAndDestroy : MonoBehaviour {

    public float scale;
    bool first = false;
    void Start () {
        StartCoroutine(scalar());
	}

	IEnumerator scalar() {
        while (!(this.transform.localScale.y < .001f) && first) {
            this.transform.localScale = this.transform.localScale * scale;
            first = true;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(this.gameObject);
    }
}
