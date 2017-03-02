using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeXFormUniversal : MonoBehaviour {

	TransformUniversal xform;
	public Vector3 transformNoiseUpper;
	public Vector3 transformNoiseLower;
	public Vector3 translateNoiseSpeed1;
    public Vector3 translateNoiseSpeed2;
    public Vector3 transformNoiseOffset1;
	public Vector3 transformNoiseOffset2;
	public Vector3 rotate1;
	public Vector3 rotate2;

	// Use this for initialization
	void Start () {
		xform = GetComponent<TransformUniversal> ();
//		xform.doTranslateNoise = true;
		xform.translateNoiseOffset = new Vector3 (
			Random.Range (transformNoiseOffset1.x, transformNoiseOffset2.x),
			Random.Range (transformNoiseOffset1.y, transformNoiseOffset2.y),
			Random.Range (transformNoiseOffset1.z, transformNoiseOffset2.z));
        xform.translateNoiseSpeed = new Vector3(
            Random.Range(translateNoiseSpeed1.x, translateNoiseSpeed2.x),
            Random.Range(translateNoiseSpeed1.y, translateNoiseSpeed2.y),
            Random.Range(translateNoiseSpeed1.z, translateNoiseSpeed2.z));
        //		xform.doRotate = true;
        xform.rotate = new Vector3 (
			Random.Range (rotate1.x, rotate2.x),
			Random.Range (rotate1.y, rotate2.y),
			Random.Range (rotate1.z, rotate2.z));

	}

}
