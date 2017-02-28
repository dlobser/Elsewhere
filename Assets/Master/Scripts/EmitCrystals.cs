using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitCrystals : MonoBehaviour {

	public float rate;
	public ON_MouseInteraction mouse;
	public GameObject[] crystals;
	float counter = 0;
	public float scaleMin;
	public float scaleMax;
	public GameObject container;
    public float crystalDistance = 1;

	public int maxCrystals;
	int crystalAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (mouse.hitObject != null) {
            if (!mouse.hitPosition.Equals(Vector3.zero) &&
                mouse.hitObject.GetComponent<Crystalizable>() != null &&
                crystalAmount < maxCrystals &&
                Vector3.Distance(mouse.hitPosition, Camera.main.transform.position) > crystalDistance) {
                if (rate > 0 && counter == 0) {
                    float scale = Random.Range(scaleMin, scaleMax);
                    Vector3 scalar = new Vector3(scale, scale, scale);
                    GameObject g = Instantiate(crystals[(int)(Random.value * (crystals.Length - 1))]);
                    g.transform.position = mouse.hitPosition;
                    g.transform.localEulerAngles = mouse.hitNormal * 360;
                    g.transform.localScale = scalar;
                    g.transform.SetParent(container.transform);
                    crystalAmount++;
                }
            }
        }
		counter += Time.deltaTime*rate;

		if (counter > 1)
			counter = 0;
	}
}
