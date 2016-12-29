using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingSimplePingTriggers : ON_NodePing {

    ON_Node node;
    public bool ping;
    public int maxPingAge;
    int pingAge = 0;

    public SimpleTrigger[] simpleTriggers;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        pingSpeed = node.pingSpeed;
        maxPingAge = node.maxPingAge;
    }

    public override void Ping(int age)
    {
         Ping();
    }

    public override void Ping()
    {
        for (int i = 0; i < simpleTriggers.Length; i++)
        {
            simpleTriggers[i].Ping();
        }
    }

}
