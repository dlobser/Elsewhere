using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTheWorld : MonoBehaviour {

    public ON_MouseInteraction mouse;
    public GameObject trail;
    GameObject Trail;
    public GameObject lazor;
    public GameObject[] sources;
    GameObject source;
    GameObject privateLazor;
    Vector3 init;
    public float laserWidth;
    public float particleAmount;
    public float trailWidth;
    public float trailTime;
    public float fadeSpeed;
    Vector3 prevPosition;
    float counter;
    float avgDistance = 1;
    float prevScale = 0;

    // Use this for initialization
    void Start () {
        privateLazor = Instantiate(lazor);
        Trail = Instantiate(trail);
        init = new Vector3(0, -1e6f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (mouse.beenHit) {
            FindClosestSource();
            counter = Mathf.Min(1,Mathf.Max(0,((avgDistance-.1f))));
            privateLazor.transform.position = Vector3.Lerp(mouse.hitPosition, source.transform.position, .5f);
            privateLazor.transform.LookAt(source.transform.position);
            float scale = Vector3.Distance(source.transform.position, mouse.hitPosition);
            privateLazor.transform.localScale = new Vector3(counter*laserWidth, counter*laserWidth,prevScale);
            Trail.transform.position = mouse.hitPosition;
            Trail.GetComponent<TrailRenderer>().widthMultiplier = counter * trailWidth;
            Trail.GetComponent<TrailRenderer>().time = counter * trailTime;
            Trail.GetComponent<ParticleSystem>().emissionRate = counter * particleAmount;
            prevScale = scale;
          
        }
        else if (counter > 0) {
            counter -= Time.deltaTime * fadeSpeed ;
            privateLazor.transform.localScale = new Vector3(counter * laserWidth, counter * laserWidth, prevScale);
            Trail.GetComponent<TrailRenderer>().widthMultiplier = counter * trailWidth;
            Trail.GetComponent<TrailRenderer>().time = counter * trailTime ;
            Trail.GetComponent<ParticleSystem>().emissionRate = counter * particleAmount;
        }
        else {
            privateLazor.transform.position = init;
            prevScale = 0;
        }

      
        avgDistance *= 10;
        avgDistance += Vector3.Distance(mouse.hitPosition, prevPosition);
        avgDistance /= 11;
        prevPosition = mouse.hitPosition;

    }
    void FindClosestSource() {

        float dist = 1e6f;
        int which = 0;
        for (int i = 0; i < sources.Length; i++) {
            if (dist > Vector3.Distance(sources[i].transform.position, mouse.hitPosition)) {
                dist = Vector3.Distance(sources[i].transform.position, mouse.hitPosition);
                which = i;
            }
        }
        source = sources[which];
    }
}
