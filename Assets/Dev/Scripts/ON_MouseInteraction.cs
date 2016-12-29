using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_MouseInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.ray
        //RaycastHit hit  = Physics.Raycast(ray);

        //Debug.Log(hit.point);
        //Debug.DrawRay(ray.origin, ray.direction);
        //if (hit.collider != null)
        //{
        //    Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        //}


        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            if (hitInfo.transform.gameObject.GetComponent<ON_Display>() != null)
            {
                Trigger pinger = hitInfo.transform.gameObject.GetComponent<Trigger>();
                Debug.Log(pinger);
                if (pinger != null)
                    pinger.Ping();

                //ON_Node pinger = hitInfo.transform.gameObject.GetComponent<ON_Display>().connectedNode;
                //if (pinger != null)
                //    pinger.Ping(1);
            }
            //if (hitInfo.transform.gameObject.GetComponent<Trigger>() != null)
            //{
            //    Trigger[] pingers = hitInfo.transform.gameObject.GetComponents<Trigger>();
            //    if (pingers.Length > 0)
            //    {
            //        for (int i = 0; i < pingers.Length; i++)
            //        {
            //            pingers[i].Ping();
            //        }
            //    }
            //}
        }
    }
}

