using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerDeactivate : SimpleTrigger {

    public float speed;
    float counter = 0;

    public override void Ping()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        
        while (counter < speed)
        {
            counter += Time.deltaTime ;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        this.gameObject.SetActive(false);
        
    }
}
