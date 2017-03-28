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
        yield return new WaitForSeconds(.2f);
        while (!(this.transform.localScale.y < .001f) ) {
            this.transform.localScale = this.transform.localScale * scale;
            first = true;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(this.gameObject);
    }
}
