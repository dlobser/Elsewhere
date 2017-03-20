using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_ScatterCrystals : MonoBehaviour {

    public float minRadius;
    public float maxRadius;
    public GameObject crystal;
    public int amount;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < amount; i++) {
            GameObject g = Instantiate(crystal);
            Vector3 rand = Random.insideUnitCircle.normalized;
            rand = new Vector3(rand.x, 0, rand.y);
            rand *= Random.Range(minRadius, maxRadius);
            g.transform.localPosition = rand;
            g.transform.localEulerAngles = Random.insideUnitSphere * 36f;
            g.transform.localScale *= Random.value + 1f;
            g.transform.parent = this.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
