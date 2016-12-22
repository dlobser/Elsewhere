using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    //public bool;
    public float timeToTrigger = 0;
    float triggerCounter = 0;
    public bool pinged;
    public SimpleTrigger[] triggers;
    public TriggerPrewarm[] prewarms;

	// Use this for initialization
	void Start () {
        triggers = GetComponents<SimpleTrigger>();
        prewarms = GetComponents<TriggerPrewarm>();
	}
	
	// Update is called once per frame
	public void Ping () {
        pinged = true;
   	}

    private void Update()
    {
        if (pinged)
        {
            if (triggerCounter < timeToTrigger)
            {
                triggerCounter += Time.deltaTime;
                for (int i = 0; i < prewarms.Length; i++){
                    prewarms[i].Animate(triggerCounter / timeToTrigger);
                }
            }
            else
            {
                for (int i = 0; i < triggers.Length; i++)
                {
                    triggers[i].Ping();
                }

            }
        }
        else if (!pinged && triggerCounter>0) { 
            triggerCounter -= Time.deltaTime;
            for (int i = 0; i < prewarms.Length; i++){
                prewarms[i].Animate(triggerCounter / timeToTrigger);
            }
        }


        pinged = false;
    }
}
