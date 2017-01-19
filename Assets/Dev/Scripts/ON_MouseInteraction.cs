using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_MouseInteraction : MonoBehaviour {

    public bool UseMouse;

    void Update() {

        if (UseMouse) { 
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                if (hitInfo.transform.gameObject.GetComponent<ON_Display>() != null) {
                    Trigger pinger = hitInfo.transform.gameObject.GetComponent<Trigger>();
                    if (pinger != null)
                        pinger.Ping();
                }

            }
        }

        else {
            RaycastHit hitInfo = new RaycastHit();
            Camera cam = Camera.main;
            //Debug.DrawRay (cam.transform.position, cam.transform.forward, Color.green);
            bool hit = Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out hitInfo, 1e6f);// ( Camera.main.ViewportPointToRay(new Vector3(.5f,.5f,0)), out hitInfo);
            //Debug.Log(hit);
            if (hit) {
                if (hitInfo.transform.gameObject.GetComponent<ON_Display>() != null) {
                    Trigger pinger = hitInfo.transform.gameObject.GetComponent<Trigger>();
                    if (pinger != null)
                        pinger.Ping();
                }

            }
        }
    }
}

