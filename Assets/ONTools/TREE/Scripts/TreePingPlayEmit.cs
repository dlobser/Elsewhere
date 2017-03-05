using UnityEngine;
using System.Collections;

namespace TREESharp{

	public class TreePingPlayEmit : TreePing {

		public ParticleSystem parti;
        public int amount;


		void Start(){
	
		}

		public override void Ping(){
            parti.Emit(amount);
		}

	}
}
