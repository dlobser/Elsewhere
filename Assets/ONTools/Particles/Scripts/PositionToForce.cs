using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ONGLParticles{
	public class PositionToForce : MonoBehaviour {

		public Material mat;
        public Material billboardMat;
		public string property;
        public float power;
        public string floatProperty;
        public float width;
        bool reverse;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
            if (Input.GetKeyDown(KeyCode.RightBracket)) {
                width += .001f;
                billboardMat.SetFloat("_LineWidth", width);
            }
            if (Input.GetKeyDown(KeyCode.LeftBracket)) {
                width -= .001f;
                billboardMat.SetFloat("_LineWidth", width);
            }
            if (Input.GetKeyDown(KeyCode.A))
                power *= .5f;
            if (Input.GetKeyDown(KeyCode.D))
                power *= 2;
            if (Input.GetKey(KeyCode.W))
                reverse = true;
            else
                reverse = false;

            mat.SetFloat(floatProperty, reverse? power*-1 : power);
			mat.SetVector (property, this.transform.position);
		}
	}
}