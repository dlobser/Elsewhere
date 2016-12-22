﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerDeathRay : SimpleTrigger
{

    public float speed;
    float counter = 0;
    public GameObject sourceObject;
    public GameObject laserPrefab;
    GameObject laser;


    public override void Ping()
    {
        if (!triggered) { 
            triggered = true;
            laser = Instantiate(laserPrefab);
            laser.transform.position = Vector3.Lerp(this.transform.position, sourceObject.transform.position, .5f);
            laser.transform.LookAt(sourceObject.transform.position);
            counter = laser.transform.localScale.x;
            laser.transform.localScale = new Vector3(counter, counter, Vector3.Distance(sourceObject.transform.position, this.transform.position));
            StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {

        while (counter > 0)
        {
            counter -= Time.deltaTime*speed;
            counter = Mathf.Max(0, counter);
            laser.transform.localScale = new Vector3(counter, counter, Vector3.Distance(sourceObject.transform.position, this.transform.position));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log(laser.name);
        //laser.SetActive(false);


    }
}
