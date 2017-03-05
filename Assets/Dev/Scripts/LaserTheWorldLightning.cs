using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]

public class LaserTheWorldLightning: MonoBehaviour {

    public ON_MouseInteraction mouse;
    public GameObject trail;
	public AudioSource aud;
    GameObject Trail;
    public GameObject[] sources;
    GameObject source;
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

	Vector3 start;
	Vector3 end;
	public LineRenderer lRen;
	public int lightningDetail = 10;
	public Vector2 lightningSize;
	public float lightningJaggyness;
	public float lightningFreq;
	public float lightningSpeed;

    // Use this for initialization
    void Start () {
		lRen = GetComponent<LineRenderer> ();

		Trail = trail;//Instantiate(trail);
		if(Trail.GetComponent<AudioSource>()!=null)
			aud = Trail.GetComponent<AudioSource> ();
        init = new Vector3(0, -1e6f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (mouse.beenHit) {
            FindClosestSource();
            Debug.Log(source);
            if (source != null) {
                if (Vector3.Distance(source.transform.position,
                    mouse.hitObject.transform.position) > 1 &&
                    mouse.hitObject.GetComponent<EW_DontLaserMe>() == null) {

                    start = source.transform.position;
                    end = mouse.hitPosition;
                    counter = Mathf.Min(1, Mathf.Max(0, ((avgDistance - .1f))));
                    updateLine(start, end, counter * laserWidth);
                    //                privateLazor.transform.position = Vector3.Lerp(mouse.hitPosition, source.transform.position, .5f);
                    //                privateLazor.transform.LookAt(source.transform.position);
                    float scale = Vector3.Distance(source.transform.position, mouse.hitPosition);
                    //                privateLazor.transform.localScale = new Vector3(counter * laserWidth, counter * laserWidth, prevScale);
                    Trail.transform.position = mouse.hitPosition;
                    Trail.GetComponent<TrailRenderer>().widthMultiplier = counter * trailWidth;
                    Trail.GetComponent<TrailRenderer>().time = counter * trailTime;
                    Trail.GetComponent<ParticleSystem>().emissionRate = counter * particleAmount;
                    prevScale = scale;
                    aud.volume = counter;
                }
            }
        }
        else if (counter > 0) {
            counter -= Time.deltaTime * fadeSpeed ;
			updateLine (start, end, counter*laserWidth);
//            privateLazor.transform.localScale = new Vector3(counter * laserWidth, counter * laserWidth, prevScale);
            Trail.GetComponent<TrailRenderer>().widthMultiplier = counter * trailWidth;
            Trail.GetComponent<TrailRenderer>().time = counter * trailTime ;
            Trail.GetComponent<ParticleSystem>().emissionRate = counter * particleAmount;
			aud.volume = counter;
        }
        else {
			lRen.widthMultiplier = 0;
//            privateLazor.transform.position = init;
            prevScale = 0;
			aud.volume = 0;
        }

      
//        avgDistance *= 10;
        avgDistance = Vector3.Distance(mouse.hitPosition, prevPosition);
//        avgDistance /= 11;
        prevPosition = mouse.hitPosition;

    }

	void updateLine(Vector3 start, Vector3 end, float width){
		lRen.numPositions = lightningDetail;
		lRen.widthMultiplier = width;
		for (int i = 0; i < lightningDetail; i++) {
			float count = (float)i / ((float)lightningDetail-1);
			Vector3 lr = Vector3.Lerp(start,end,count);
			float j = lightningJaggyness;
			Vector3 jaggy =  GetNoiseVec(lr,lightningFreq) *(1f-cosFloat(count)) * j;//randVec (-j, j)
//			lRen.SetWidth (width,width);
			lRen.SetPosition (i, lr+jaggy);
		}
	}


	Vector3 randVec(float min, float max){
		return new Vector3 (Random.Range (min, max), Random.Range (min, max), Random.Range (min, max));
	}

	Vector3 randUniformVec(float min, float max){
		float r = Random.Range (min, max);
		return new Vector3 (r,r,r);
	}

	float cosFloat(float v){
		return (Mathf.Cos (v * 6.28f) + 1) * .5f;
	}

	Vector3 GetNoiseVec(Vector3 vec, float freq){
		vec *= freq;
		return new Vector3 (
			.5f-Mathf.PerlinNoise(Time.time*lightningSpeed+vec.x,vec.z),
			(.5f-Mathf.PerlinNoise(Time.time*lightningSpeed+vec.y,vec.x))*.1f,
			.5f-Mathf.PerlinNoise(Time.time*lightningSpeed+vec.z,vec.y)
		);
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
        //Debug.Log(which);
        if(which<=sources.Length-1)
            source = sources[which];
    }

	public void AddToSource(GameObject g){
		GameObject[] newSource = new GameObject[sources.Length+1];
		for (int i = 0; i < sources.Length; i++) {
			newSource [i] = sources [i];
		}
		newSource [newSource.Length - 1] = g;
		sources = newSource;
	}
}
