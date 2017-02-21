using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    //public bool;
    public float timeToTrigger = 0;
	public float returnSpeedMultiply = 1;
    float triggerCounter = 0;
    public bool pinged;
    public SimpleTrigger[] triggers;
    public TriggerPrewarm[] prewarms;
    public ON_Node node;
    bool triggerable = true;
	public bool triggerOnlyOnce = false;
	int triggerCount = 0;

    public bool neverTrigger = false;

	// Use this for initialization
	void Start () {
        triggers = GetComponents<SimpleTrigger>();
        prewarms = GetComponents<TriggerPrewarm>();
        if(GetComponent<ON_Display>()!=null)
            node = GetComponent<ON_Display>().connectedNode;
	}
	
	// Update is called once per frame
	public void Ping () {
		if (node != null) {
			if (triggerable && !node.NodePingsAreActive ()&& !triggerOnlyOnce)
				pinged = true;
			else if (triggerable && !node.NodePingsAreActive ()&& triggerOnlyOnce && triggerCount<1)
				pinged = true;
		} else if (triggerable && !triggerOnlyOnce)
			pinged = true;
		else if (triggerable && triggerOnlyOnce && triggerCount < 1)
			pinged = true;
   	}

    private void Update()
    {
        if (pinged)
        {
            if (triggerCounter < timeToTrigger)
            {
                triggerCounter += Time.deltaTime;
                for (int i = 0; i < prewarms.Length; i++) {
                    prewarms[i].Animate(triggerCounter / timeToTrigger);
                }
            }
            else if (triggerable && !neverTrigger) { 
            {
                    for (int i = 0; i < triggers.Length; i++)
                    {
                        triggers[i].Ping();
                    }
                    if(node!=null)
                        node.Ping();
					triggerCount++;
                    triggerable = false;
                }
            }
        }
        else if (!pinged && triggerCounter>0) {
			triggerCounter -= Time.deltaTime * returnSpeedMultiply;
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
