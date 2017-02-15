using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerDeathRay : SimpleTrigger
{

    public float speed;
    float counter = 0;
    public GameObject sourceObject;
    public GameObject laserPrefab;
    public GameObject soundObject;
    GameObject laser;
    GameObject part;

    public GameObject particlePrefab;

    public override void Ping()
    {
        if (!triggered) { 
            triggered = true;
            laser = Instantiate(laserPrefab);
            GameObject sound = Instantiate(soundObject);
            part = Instantiate(particlePrefab);
			part.transform.position = this.transform.position;
            part.GetComponent<ParticleSystem>().Emit(40);
            sound.transform.position = this.transform.position;
            laser.transform.position = Vector3.Lerp(this.transform.position, sourceObject.transform.position, .5f);
            laser.transform.LookAt(sourceObject.transform.position);
            counter = laser.transform.localScale.x;
            laser.transform.localScale = new Vector3(counter, counter, Vector3.Distance(sourceObject.transform.position, this.transform.position));
			this.GetComponent<MeshRenderer> ().enabled = false;
			this.GetComponent<MeshCollider> ().enabled = false;

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
        //Debug.Log(laser.name);
        //laser.SetActive(false);
        Destroy(laser);
        Destroy(part);

    }
}
