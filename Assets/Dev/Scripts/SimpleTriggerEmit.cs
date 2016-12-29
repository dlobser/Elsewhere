using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerEmit : SimpleTrigger {

    public ParticleSystem parti;

    public override void Ping()
    {
        if(parti!=null)
            parti.Emit(5);

    }
    
}
