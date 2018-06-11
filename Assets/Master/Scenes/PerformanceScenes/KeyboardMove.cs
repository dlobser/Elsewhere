using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour {

    Vector3 move = Vector3.zero;
    Vector3 rotate = Vector3.zero;
    public float rotateSpeed = .1f;
    bool moving = true;
    public float speed = .05f;
    public float returnSpeed = 3;
    Vector3 gotoPos, gotoRot;
    float returnMult = 1;

	// Use this for initialization
	void Start () {
        gotoPos = this.transform.position;
        gotoRot = this.transform.localEulerAngles;
	}

    IEnumerator reset() {
        float counter = 0;
        Vector3 initPos = this.transform.position;
        Vector3 initRot = this.transform.localEulerAngles;
        move = Vector3.zero;
        rotate = Vector3.zero;
        while (counter < returnSpeed) {
            this.transform.position = Vector3.Lerp(initPos, gotoPos, Mathf.SmoothStep(0,1, counter / returnSpeed));
            this.transform.localEulerAngles = Vector3.Lerp(initRot,gotoRot, Mathf.SmoothStep(0,1, counter / returnSpeed));
            counter += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            move = Vector3.Lerp(move, Vector3.left, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D)) {
            move = Vector3.Lerp(move, Vector3.right, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.W)) {
            move = Vector3.Lerp(move, Vector3.forward, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            move = Vector3.Lerp(move, Vector3.back, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.Q)) {
            move = Vector3.Lerp(move, Vector3.down, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.E)) {
            move = Vector3.Lerp(move, Vector3.up, speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.Z)) {
            rotate.Set(rotate.x, Mathf.Lerp(rotate.y, -1, rotateSpeed * Time.deltaTime), rotate.z);
            moving = true;
        }
        if (Input.GetKey(KeyCode.C)) {
            rotate.Set(rotate.x, Mathf.Lerp(rotate.y, 1, rotateSpeed * Time.deltaTime), rotate.z);
            moving = true;
        }
        if (Input.GetKey(KeyCode.F)) {
            rotate.Set(Mathf.Lerp(rotate.x, -1, rotateSpeed * Time.deltaTime), rotate.y , rotate.z);
            moving = true;
        }
        if (Input.GetKey(KeyCode.V)) {
            rotate.Set(Mathf.Lerp(rotate.x, 1, rotateSpeed * Time.deltaTime), rotate.y, rotate.z);
            moving = true;
        }
        if (Input.GetKey(KeyCode.K)) {

            returnMult = 100;
        }
        else
            returnMult = 1;
        if (!moving) {
            move = Vector3.Lerp(move, Vector3.zero, speed * Time.deltaTime * returnMult);
            rotate = Vector3.Lerp(rotate, Vector3.zero, rotateSpeed * Time.deltaTime* returnMult);
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            StartCoroutine(reset());
      
        }
        moving = false;
        this.transform.Translate(move);
        this.transform.Rotate(rotate);
	}
}
