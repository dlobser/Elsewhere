using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingSimpleWire : ON_NodePing {

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
            pingers = new List<GameObject>();
            for (int i = 0; i < node.siblings.Count; i++)
            {
                if (!node.siblings[i].NodePingsAreActive())// !(node.siblings[i].GetComponent<ON_NodePing>().resetTimer > 0))
                {
                    GameObject p = Instantiate(pinger);
                    p.GetComponent<ChooseRandomAudio>().Choose();
                    p.GetComponent<AudioSource>().Play();
                    p.transform.parent = pingContainer.transform;
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
        float dist = Vector3.Distance(this.transform.position, sibling.transform.position);
        while (counter < 1)
        {
            counter += (Time.deltaTime *( pingSpeed/dist));
            pingGeo.transform.position = Vector3.Lerp(this.transform.position, sibling.transform.position,(counter/1) * .5f);
            pingGeo.transform.LookAt(sibling.transform.position);
            pingGeo.transform.localScale = new Vector3(pingGeo.transform.localScale.x  , pingGeo.transform.localScale.y , dist * (counter/1) );
            yield return new WaitForSeconds(Time.deltaTime);
        }

        while (counter < 3)
        {
            counter += (Time.deltaTime * (pingSpeed / dist));
            pingGeo.transform.localScale = new Vector3(pingGeo.transform.localScale.x * (1 - ((counter - 1) / 2)), pingGeo.transform.localScale.y * (1 - ((counter - 1) / 2)), dist);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(pingGeo);

    }
}
