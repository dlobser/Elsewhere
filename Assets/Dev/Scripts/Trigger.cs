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
    public ON_Node node;
    bool triggerable = true;

	// Use this for initialization
	void Start () {
        triggers = GetComponents<SimpleTrigger>();
        prewarms = GetComponents<TriggerPrewarm>();
        node = GetComponent<ON_Display>().connectedNode;
	}
	
	// Update is called once per frame
	public void Ping () {
        if(triggerable && !node.NodePingsAreActive())
            pinged = true;
   	}

    private void Update()
    {
        if (pinged)
        {
            Debug.Log("trigger");
            if (triggerCounter < timeToTrigger)
            {
                triggerCounter += Time.deltaTime;
                for (int i = 0; i < prewarms.Length; i++) {
                    prewarms[i].Animate(triggerCounter / timeToTrigger);
                }
            }
            else if (triggerable) { 
            {
                    for (int i = 0; i < triggers.Length; i++)
                    {
                        triggers[i].Ping();

                    }
                    node.Ping();
                    triggerable = false;
                }
            }
        }
        else if (!pinged && triggerCounter>0) { 
            triggerCounter -= Time.deltaTime;
            for (int i = 0; i < prewarms.Length; i++){
                prewarms[i].Animate(triggerCounter / timeToTrigger);
            }
        }
        else if (triggerCounter <= 0 && !triggerable)
        {
            triggerable = true;
            for (int i = 0; i < prewarms.Length; i++)
            {
                prewarms[i].Reset();
            }
        }
        pinged = false;
    }
}
