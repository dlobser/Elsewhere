﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingSimple : ON_NodePing {

    ON_Node node;
    //public bool ping { get; set; }
    //public int maxPingAge;
    int pingAge = 0;
    GameObject nodeGeo;

	public float neighborPingLikelihood;
    //public bool pingOnlyOne;


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
            if (pingAge < maxPingAge) {
                pinged = true;
                StartCoroutine(CountDownToReset());
                //int which = (int) Random.Range(0, node.siblings.Count);
                for (int i = 0; i < node.siblings.Count; i++) {

                    if (!node.siblings[i].NodePingsAreActive() && Random.value < neighborPingLikelihood) {
                        StartCoroutine(PingAnimation(node.siblings[i]));
                    }

                }
            }

        }
    }

    IEnumerator CountDownToReset()
    {
       
        resetTimer = timeToReset;
        while (resetTimer > 0){
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
        float dist = Vector3.Distance(this.transform.localPosition, sibling.transform.localPosition);

        while (counter < 1){
            counter += (Time.deltaTime * (pingSpeed / dist));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        sibling.Ping(pingAge);
    }
}
