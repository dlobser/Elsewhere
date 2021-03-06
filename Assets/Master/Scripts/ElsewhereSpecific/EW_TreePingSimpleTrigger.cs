﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TREESharp;

public class EW_TreePingSimpleTrigger : SimpleTrigger {

    public float delay;
	public bool pingable { get; set; }

	void Start(){
		pingable = true;
	}
    public override void Ping() {

		if (pingable)
			StartCoroutine (Traverse (this.gameObject));
//		else
//			StopCoroutine (Traverse (this.gameObject));
    }

    IEnumerator Traverse(GameObject Joint) {
        TREESharp.Joint J = Joint.GetComponent<TREESharp.Joint>();
        TREESharp.TreePing[] P = Joint.GetComponents<TREESharp.TreePing>();

        yield return new WaitForSeconds(delay);// * J.scalar.transform.lossyScale.y);
//		if (pingable) {
			for (int i = 0; i < P.Length; i++) {
			
				P [i].Ping ();
			}
//		}


        if (J.childJoint != null)
            StartCoroutine(Traverse(J.childJoint));
        for (int i = 0; i < J.limbs.Count; i++) {
            StartCoroutine(Traverse(J.limbs[i]));
        }
    }

}
