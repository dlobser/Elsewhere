using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingAnimColorNode : ON_NodePing {

    ON_Node node;
    //public GameObject pinger;
    //List<GameObject> pingers;
    //public bool ping;
    //public int maxPingAge;
    int pingAge = 0;

    MeshRenderer[] mRends;

    Material mat;
    Material sharedMat;

    GameObject nodeGeo;
    public string channel;
    public Color transitionColor;
    public Color initialColor;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        pingSpeed = node.pingSpeed;
        timeToReset = node.timeToReset;
        maxPingAge = node.maxPingAge;
        nodeGeo = node.display;
       

        ////initialColor = sharedMat.color;
    }

    void Update()
    {
        if (ping && resetTimer == 0 )
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

    void ChangeColor(Color col)
    {
        for (int i = 0; i < mRends.Length; i++)
        {
            mRends[i].material.SetColor(channel, col);
        }
    }

    IEnumerator CountDownToReset()
    {
        mRends = node.display.GetComponentsInChildren<MeshRenderer>();

        resetTimer = timeToReset;
        //node.display.GetComponentInChildren<MeshRenderer>().material = mat;
        while (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            Color col = Color.Lerp(initialColor, transitionColor , resetTimer / timeToReset);

            ChangeColor(col);
            //float scalar = Mathf.Lerp(endScale, startScale, resetTimer / timeToReset);
            //nodeGeo.transform.localScale = new Vector3(scalar, scalar, scalar);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        ChangeColor(initialColor);
        pinged = false;
        pingAge = 0;
        resetTimer = 0;
    }

 
}
