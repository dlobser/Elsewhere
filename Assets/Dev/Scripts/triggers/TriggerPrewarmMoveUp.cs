using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmMoveUp : TriggerPrewarm {

	public float moveTo;
	Vector3 oldLocation;
	Vector3 newLocation;

    public override void Animate(float t) {
		this.transform.localPosition = Vector3.Lerp (oldLocation, newLocation, t);
    }

    public override void Reset()
    {
//		this.transform.localPosition = oldLocation;
    }

    void Start()
    {
		oldLocation = this.transform.localPosition;
		newLocation = oldLocation + new Vector3 (0, moveTo, 0);
    }


}
