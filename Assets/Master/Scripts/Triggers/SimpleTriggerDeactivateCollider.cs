using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerDeactivateCollider : SimpleTrigger {


    public override void Ping()
    {
        if(this.GetComponent<Collider>()!=null)
            this.GetComponent<Collider>().enabled = false;
      

    }
    
}
