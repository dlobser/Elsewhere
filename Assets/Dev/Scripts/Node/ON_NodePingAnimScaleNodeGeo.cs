using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingAnimScaleNodeGeo : ON_NodePing {

    ON_Node node;
    //public GameObject pinger;
    //List<GameObject> pingers;
    public bool ping;
    public int maxPingAge;
    int pingAge = 0;

    GameObject nodeGeo;

    public float startScale;
    public float endScale;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        pingSpeed = node.pingSpeed;
        timeToReset = node.timeToReset;
        maxPingAge = node.maxPingAge;
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
        }
    }

    IEnumerator CountDownToReset()
    {
       
        resetTimer = timeToReset;
        while (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            float scalar = Mathf.Lerp(endScale, startScale, resetTimer / timeToReset);
            if(nodeGeo!=null)
                nodeGeo.transform.localScale = new Vector3(scalar, scalar, scalar);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        pinged = false;
        pingAge = 0;
        resetTimer = 0;
    }

 
}
