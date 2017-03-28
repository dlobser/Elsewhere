using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerScaleDown : SimpleTrigger {

    public float scalar = 1;
    public override void Ping() {
        this.transform.localScale = new Vector3(
            this.transform.localScale.x * scalar,
            this.transform.localScale.y * scalar,
            this.transform.localScale.z * scalar);
    }
 }
