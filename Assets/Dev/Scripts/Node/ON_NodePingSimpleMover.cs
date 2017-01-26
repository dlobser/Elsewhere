using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePingSimpleMover : ON_NodePing {

    ON_Node node;
    //public GameObject pinger;
    List<GameObject> pingers;
    public ON_ObjectPool pool;

	public bool bounce = false;
	public float bounceHeight = 0;
	public float initialTrailRendererTime;
    ////public bool ping;
    //public int maxPingAge;
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
            pinged = true;
            pingers = new List<GameObject>();
            for (int i = 0; i < node.siblings.Count; i++)
            {
                if (!node.siblings[i].NodePingsAreActive())// !(node.siblings[i].GetComponent<ON_NodePing>().resetTimer > 0))
                {
                    GameObject p = pool.PoolInstantiate();// Instantiate(pinger);
                    //p.GetComponent<ChooseRandomAudio>().Choose();
                    //p.GetComponent<AudioSource>().Play();
					if (p.GetComponent<TrailRenderer> () != null) {
						p.GetComponent<TrailRenderer> ().Clear ();

						//						initialTrailRendererTime = p.GetComponent<TrailRenderer> ().time;
						p.GetComponent<TrailRenderer> ().time = 0;
					}
					p.transform.position = this.transform.position;
                    p.transform.parent = pingContainer.transform;

				

                    pingers.Add(p);
                    float newAge = Mathf.Max(1, pingAge);
                    //p.transform.localScale = new Vector3(p.transform.localScale.x / newAge, p.transform.localScale.y / newAge, p.transform.localScale.z / newAge);
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
		float dist = Vector3.Distance (this.transform.localPosition, sibling.transform.localPosition);
		float inScale = pingGeo.transform.localScale.x;
		pingGeo.transform.LookAt (sibling.transform.position);

		Vector3 newHeight = Vector3.zero;


		if (pingGeo.GetComponent<TrailRenderer> () != null) {
			pingGeo.GetComponent<TrailRenderer> ().time = initialTrailRendererTime;
		}
			
		while (counter < 1) {
			counter += (Time.deltaTime * (pingSpeed / dist));
			pingGeo.transform.localPosition = Vector3.Lerp (this.transform.localPosition, sibling.transform.localPosition, (counter / 1));
			float sc = Mathf.Sin (Mathf.PI * (counter / 1));// ((Mathf.Cos(Mathf.PI * 2 * (counter / 1)) - 1) * -.5f);
			sc *= inScale;
			pingGeo.transform.localScale = new Vector3 (sc, sc, sc);

			if (bounce) {
				newHeight.Set (0, sc * bounceHeight, 0);
				pingGeo.transform.Translate (newHeight);
			}

			//pingGeo.transform.localScale = new Vector3(pingGeo.transform.localScale.x  , pingGeo.transform.localScale.y , dist * (counter/1) );
			yield return new WaitForSeconds (Time.deltaTime);
		}

		if (pingGeo.GetComponent<TrailRenderer> () != null) {
			counter = 0;
			float width = pingGeo.GetComponent<TrailRenderer> ().widthMultiplier;
			while (counter < 1) {
				counter += (Time.deltaTime * (pingSpeed / dist));
				pingGeo.GetComponent<TrailRenderer> ().time = (1 - counter) * initialTrailRendererTime;
				pingGeo.GetComponent<TrailRenderer> ().widthMultiplier = (1 - counter) * width;
				yield return new WaitForSeconds (Time.deltaTime);

			}
			pingGeo.GetComponent<TrailRenderer> ().widthMultiplier = width;
		}
	

		if (pingGeo.GetComponent<TrailRenderer> () != null) {
			pingGeo.GetComponent<TrailRenderer> ().Clear ();// .enabled = false;
		}

        pool.PoolDestroy(pingGeo);
        //Destroy(pingGeo);

    }
}
