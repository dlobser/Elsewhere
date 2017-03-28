using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent (typeof (LineRenderer))]

public class makeLightning : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	LineRenderer lRen;
	public GameObject cloud;
	public int cloudAmount;
	public float cloudSpread;
	public Vector2 cloudScale;
	List<GameObject> clouds;

	public int lightningDetail = 10;
	public Vector2 lightningSize;
	public float lightningJaggyness;
	public float lightningFreq;
	public float lightningSpeed;


	// Use this for initialization
	void Start () {
		lRen = GetComponent<LineRenderer> ();
		lRen.SetVertexCount (lightningDetail);
		lRen.SetWidth (lightningSize.x, lightningSize.y);
		makeClouds ();
		updateClouds ();
	}
	
	// Update is called once per frame
	void Update () {
		updateLine ();
		updateClouds ();

	}

	void updateLine(){
		for (int i = 0; i < lightningDetail; i++) {
			float count = (float)i / (float)lightningDetail;
			Vector3 lr = Vector3.Lerp(start.transform.localPosition,end.transform.localPosition,count);
			float j = lightningJaggyness;
			Vector3 jaggy =  GetNoiseVec(lr,lightningFreq) *(1f-cosFloat(count)) * j;//randVec (-j, j)
			lRen.SetWidth (lightningSize.x, lightningSize.y);
			lRen.SetPosition (i, lr+jaggy);
		}
	}

	void updateClouds(){
		for (int i = 0; i < cloudAmount; i++) {
			clouds [i].transform.localScale = Vector3.Scale(randUniformVec(cloudScale.x, cloudScale.y),new Vector3(1f,1f,.1f));
			clouds [i].transform.position = randVec (-cloudSpread, cloudSpread) + start.transform.localPosition;
		}
	}

	void makeClouds(){
		clouds = new List<GameObject> ();
		for (int i = 0; i < cloudAmount; i++) {
			clouds.Add (Instantiate (cloud,randVec (-cloudSpread, cloudSpread),Quaternion.identity,this.transform)as GameObject);
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



}
