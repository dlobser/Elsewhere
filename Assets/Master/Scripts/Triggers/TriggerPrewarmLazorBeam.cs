using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmLazorBeam : TriggerPrewarm
{

    public ON_MouseInteraction mouse;
    public GameObject trail;
    public GameObject lazor;
    public GameObject source;
    GameObject privateLazor;
    Vector3 init;
    void Awake() {
        privateLazor = Instantiate(lazor);
        init = new Vector3(0, -1e6f, 0);
    }
   
    public override void Animate(float t)
    {
        privateLazor.transform.position = Vector3.Lerp(this.transform.position, source.transform.position, .5f);
        privateLazor.transform.LookAt(source.transform.position);
    }

	public override void Reset()
	{
        privateLazor.transform.position = init;
        trail.SetActive(false);

	}



}
