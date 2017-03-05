using UnityEngine;
using System.Collections;

namespace TREESharp{

	public class TreePingColor : TreePing {

		Color init;
		public Color color;
        public Color initialColor;
        public bool useInitialColor;
		float counter = 0;
		MeshRenderer[] rend;
		public float speed = 1;
        public string channel;
        Material initMat;

		void Start(){
			rend = new MeshRenderer[1];
            rend[0] = this.GetComponent<Joint>().scalar.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
            initMat = rend[0].sharedMaterial;
        }

        public override void Ping(){

            if (!useInitialColor)
                init = initMat.GetColor(channel);
            else
                init = initialColor;
			StartCoroutine (scale ());
		}

		IEnumerator scale(){
			while(counter<1){
				counter += Time.deltaTime;
				for (int i = 0; i < rend.Length; i++) {
					if(rend[i]!=null)
						if(rend[i].material!=null)
							rend[i].material.SetColor(channel,Color.Lerp (color, init, counter));

				}
				yield return new WaitForSeconds (Time.deltaTime*speed);
			}
            rend[0].material = initMat;
			counter = 0;
		}
	}
}
