using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_MouseInteraction : MonoBehaviour {

    public bool UseMouse;
    public Vector3 hitPosition;
    public Vector3 hitNormal;
	public GameObject hitObject;
    public bool beenHit;
    void Update() {

        if (UseMouse) { 
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            beenHit = hit;
            if (hit) {
//                if (hitInfo.transform.gameObject.GetComponent<ON_Display>() != null) {
                    Trigger pinger = hitInfo.transform.gameObject.GetComponent<Trigger>();
                    hitPosition = hitInfo.point;
                    hitNormal = hitInfo.normal;
					hitObject = hitInfo.collider.gameObject;
//				Debug.Log (hitObject);
                if (pinger != null)
                        pinger.Ping();
//                }

            }
            else {
                hitPosition = Vector3.zero;
                hitNormal = Vector3.zero;
				hitObject = null;
            }
        }

        else {
            RaycastHit hitInfo = new RaycastHit();
            Camera cam = Camera.main;
            Debug.DrawRay (cam.transform.position, cam.transform.forward*1000f, Color.green);
            bool hit = Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out hitInfo, 1e6f);// ( Camera.main.ViewportPointToRay(new Vector3(.5f,.5f,0)), out hitInfo);
            //Debug.Log(hit);
            beenHit = hit;
            if (hit) {
           
                //if (hitInfo.transform.gameObject.GetComponent<Trigger>() != null) {
                    Trigger pinger = hitInfo.transform.gameObject.GetComponent<Trigger>();
                    hitPosition = hitInfo.point;
                    hitNormal = hitInfo.normal;
                    hitObject = hitInfo.collider.gameObject;
                if (pinger != null)
                        pinger.Ping();
                //}

            }
            else {
                hitPosition = Vector3.zero;
                hitNormal = Vector3.zero;
                hitObject = null;
            }
        }
    }
}

