using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerScaleUp : SimpleTrigger {

    public Vector3 scalar;
    public override void Ping() {
        this.transform.localScale = new Vector3(
            this.transform.localScale.x + scalar.x,
            this.transform.localScale.y + scalar.y,
            this.transform.localScale.z + scalar.z);
    }
 }
