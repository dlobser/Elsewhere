using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_Duplicate : MonoBehaviour {
    public int amount;
    public Vector3 offset;
    public Vector3 offset2;
    public GameObject GO;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < amount; i++) {
            for (int j = 0; j < amount; j++) {
                GameObject g = Instantiate(GO);
                if(i%2==0)
                    g.transform.localPosition = new Vector3((i * 1.5f)-(amount*.7f), 0,j*1.75f-(amount * .7f));
                else
                    g.transform.localPosition = new Vector3((i * 1.5f)-(amount * .7f), 0, ((j*1.75f)+.875f) - (amount * .7f));

                float dist = Vector3.Distance(g.transform.localPosition, Vector3.zero);
                g.transform.Translate(new Vector3(0, dist*.4f, 0));
            }
           

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
