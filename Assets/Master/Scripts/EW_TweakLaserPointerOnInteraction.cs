using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_TweakLaserPointerOnInteraction : MonoBehaviour {

    public Vector3 scalar;
    Vector3 init;
    bool beenHit;
    public copyTransformsName copyXForms;
    GameObject whichController;

    void OnEnable() {
        ON_MouseInteraction.mouseHasHit += Scalar;
    }


    void OnDisable() {
        ON_MouseInteraction.mouseHasHit -= Scalar;
    }


    void Scalar() {
        beenHit = true;
        scalar = new Vector3(init.x, init.y,Vector3.Distance(ON_MouseInteraction.theHitPosition, this.transform.position) *2);
        if (ON_MouseInteraction.rayObject == whichController && ON_MouseInteraction.theHitObject.GetComponent<EW_DontLaserMe>()==null)
            this.transform.localScale = scalar;
    }

    // Use this for initialization
    void Start () {
        whichController = copyXForms.theTarget;
        init = this.transform.localScale;
	}

    
	// Update is called once per frame
	void Update () {
        if (!beenHit)
            this.transform.localScale = init;
        if(whichController==null)
            whichController = copyXForms.theTarget;

        beenHit = false;
	}
}
