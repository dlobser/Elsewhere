using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingAnimEmitParticles : ON_NodePing {

    ON_Node node;
    //public GameObject pinger;
    //List<GameObject> pingers;
    public bool ping;
    public int maxPingAge;
    int pingAge = 0;

    ParticleSystem[] particles;

    GameObject nodeGeo;

    public float rate;

    private void Start()
    {
        node = GetComponent<ON_Node>();
        pingSpeed = node.pingSpeed;
        timeToReset = node.timeToReset;
        maxPingAge = node.maxPingAge;
        nodeGeo = node.display;
       

        //initialColor = sharedMat.color;
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
        particles = node.display.GetComponentsInChildren<ParticleSystem>();
        pingAge = age;
        if(pingAge<maxPingAge)
            Ping();
    }

    public override void Ping()
    {
        ChangeEmission(rate);
        //if (!pinged)
        //{
        //    pingAge++;
        //    pinged = true;
        //    StartCoroutine(CountDownToReset());
        //}
    }

    void ChangeEmission(float rate)
    {
        for (int i = 0; i < particles.Length; i++)
        {
            //particles[i].emissionRate = rate;
            particles[i].Emit((int)rate);
        }
    }

    IEnumerator CountDownToReset()
    {
       
        resetTimer = timeToReset;
        //node.display.GetComponentInChildren<MeshRenderer>().material = mat;
        while (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            float eRate = Mathf.Lerp(rate, 0 , resetTimer / timeToReset);

            ChangeEmission(eRate);
            //float scalar = Mathf.Lerp(endScale, startScale, resetTimer / timeToReset);
            //nodeGeo.transform.localScale = new Vector3(scalar, scalar, scalar);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        ChangeEmission(0);
        pinged = false;
        pingAge = 0;
        resetTimer = 0;
    }

 
}
