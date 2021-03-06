﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerDeathrayOthers : SimpleTrigger {

    public float speed;
    float counter = 0;

    public GameObject[] Objects;

    public override void Ping()
    {
        if (!triggered) {
            StartCoroutine(Animate());
            triggered = true;
        }
    }

    IEnumerator Animate()
    {
        
        while (counter < speed)
        {
            counter += Time.deltaTime ;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (int i = 0; i < Objects.Length; i++) {
			Objects[i].GetComponent<SimpleTriggerPlayAudios>().Ping();
			Objects [i].GetComponent<SimpleTriggerDeathRay> ().Ping ();
			yield return new WaitForSeconds (.1f);
//            Objects[i].SetActive(false);
        }
        
    }
}
