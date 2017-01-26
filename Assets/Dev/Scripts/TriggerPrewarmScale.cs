using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmScale : TriggerPrewarm
{

    public Vector3 scaleTo;
    public Vector3 scaleFrom;

    void Awake() {
//        scaleFrom = this.transform.localScale;
		this.transform.localScale = scaleFrom;

    }
   
    public override void Animate(float t)
    {
		
        Vector3 sc = this.transform.localScale;
        this.transform.localScale = Vector3.Lerp(scaleFrom, scaleTo, Mathf.SmoothStep(0,1,t));
    }
	public override void Reset()
	{
		this.transform.localScale = scaleFrom;

	}



}
