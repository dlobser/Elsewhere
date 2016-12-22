using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingSimple : ON_NodePing {

    ON_Node node;
    public bool ping;
    public int maxPingAge;
    int pingAge = 0;
    GameObject nodeGeo;


    private void Start()
    {
        node = GetComponent<ON_Node>();
        nodeGeo = node.display;
        pingSpeed = node.pingSpeed;
        timeToReset = node.timeToReset;
        maxPingAge = node.maxPingAge;
    }

    //void Update()
    //{
    //    if (ping && resetTimer == 0)
    //    {
    //        Ping();
    //        ping = false;
    //    }
    //}

    public override void Ping(int age)
    {
        pingAge = age;
        if(pingAge<maxPingAge)
            Ping();
    }

    public override void Ping()
    {

        if (!pinged)
        {
            pingAge++;
            pinged = true;
            StartCoroutine(CountDownToReset());
            for (int i = 0; i < node.siblings.Count; i++)
            {
                if (!node.siblings[i].NodePingsAreActive())
                {
                    StartCoroutine(PingAnimation(node.siblings[i]));
                }
            }
           
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

    IEnumerator PingAnimation(ON_Node sibling)
    {
        float counter = 0;
        float dist = Vector3.Distance(this.transform.position, sibling.transform.position);

        while (counter < 1)
        {
            counter += (Time.deltaTime * (pingSpeed / dist));
            yield return new WaitForSeconds(Time.deltaTime);
        }


        sibling.Ping(pingAge);

    }


}
