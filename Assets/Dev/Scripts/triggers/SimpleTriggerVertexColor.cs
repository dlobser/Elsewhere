using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerVertexColor : SimpleTrigger {

    public TriggerVertexColor trigger;

    public override void Ping() {
        trigger.Trigger(this.GetComponent<ON_Node>().id);

    }

}
