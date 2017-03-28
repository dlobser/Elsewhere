using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingMulti : ON_NodePing {

    public ON_SubPing[] subPingers;

    ON_Node node;
    GameObject nodeGeo;

    public bool ping;
    public bool subPingersFinished = false;
    public int maxPingAge;
    int pingAge = 0;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        subPingers = GetComponents<ON_SubPing>();
        nodeGeo = node.display;
    }

    void Update()
    {
        if (ping && resetTimer == 0)
        {
            Ping();
            ping = false;
        }
    }

    public override void Ping(int age)
    {
        pingAge = age;
        if (pingAge < maxPingAge)
            Ping();
    }

    public override void Ping()
    {
        if (!pinged)
        {
            pingAge++;
            pinged = true;
 
            for (int i = 0; i < node.siblings.Count; i++)
            {
                if (node.siblings[i].GetComponent<ON_NodePing>() != null && !node.siblings[i].GetComponent<ON_NodePing>().pinged)// !(node.siblings[i].GetComponent<ON_NodePing>().resetTimer > 0))
                {
                    for (int j = 0; j < subPingers.Length; j++)
                    {
                        if (!subPingers[j].isPlaying)
                        {
                            Debug.Log(j);
                            subPingers[j].origin = node;
                            subPingers[j].sibling = node.siblings[i];
                            subPingers[j].speed = pingSpeed;
                            subPingers[j].scale = pingAge;
                            subPingers[j].pingContainer = pingContainer;
                            subPingers[j].Ping();
                        }
                    }
                }
            }

            StartCoroutine(CountDownToReset());
        }
    }


    IEnumerator CountDownToReset()
    {

        resetTimer = timeToReset;

        while (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        pinged = false;
        pingAge = 0;
        resetTimer = 0;
    }

  
}
