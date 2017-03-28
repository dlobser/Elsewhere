using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingAnimPop : ON_NodePing {

    ON_Node node;
    public GameObject pinger;
    List<GameObject> pingers;
    public bool ping;
    public int maxPingAge;
    int pingAge = 0;

    GameObject nodeGeo;

    //public float startScale;
    //public float endScale;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        nodeGeo = node.display;
        pingSpeed = node.pingSpeed;
        timeToReset = node.timeToReset;
        maxPingAge = node.maxPingAge;
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
            //pingAge++;
            pinged = true;
            pingers = new List<GameObject>();
            for (int i = 0; i < node.siblings.Count; i++)
            {

                if (node.siblings[i].GetComponent<ON_NodePing>() != null && !node.siblings[i].GetComponent<ON_NodePing>().pinged)// !(node.siblings[i].GetComponent<ON_NodePing>().resetTimer > 0))
                {

                    GameObject p = Instantiate(pinger);
                    pingers.Add(p);
                    p.transform.localScale = new Vector3(p.transform.localScale.x / pingAge, p.transform.localScale.y / pingAge, p.transform.localScale.z / pingAge);
                    StartCoroutine(PingAnimation(p, node.siblings[i]));
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

    IEnumerator PingAnimation(GameObject pingGeo, ON_Node sibling)
    {
        float counter = 0;
        //ON_NodePing nodePing = sibling.GetComponent<ON_NodePing>();
        float inScale = pingGeo.transform.localScale.x;
        while (counter < 1)
        {
            float dist = Vector3.Distance(this.transform.position, sibling.transform.position);
            counter += (Time.deltaTime *( pingSpeed/dist));
            pingGeo.transform.position = Vector3.Lerp(this.transform.position, sibling.transform.position, counter / 1);
            float sc = ((Mathf.Cos(Mathf.PI*2*(counter/1))-1)*-.5f);
            sc *= inScale;
            pingGeo.transform.localScale = new Vector3(sc, sc, sc);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(pingGeo);
    }
}
