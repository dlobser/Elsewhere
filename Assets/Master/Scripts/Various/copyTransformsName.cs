using UnityEngine;
using System.Collections;

public class copyTransformsName : MonoBehaviour {

    public string target;
    public GameObject theTarget {get;set;}

    private void Start() {
        theTarget = GameObject.Find(target);
    }

	void Update () {
        if (theTarget == null)
            theTarget = GameObject.Find(target);
        if(theTarget != null)
		    DLUtility.copyWorldTransforms (theTarget, transform.gameObject);
	}
}
