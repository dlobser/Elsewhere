using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EW_DeactivateTriggerForTimeFromPing : MonoBehaviour {

namespace TREESharp{

	public class EW_DeactivateTriggerForTimeFromPing : TreePing {

		public Trigger trig;
		public EW_TreePingSimpleTrigger ping;
		public float fadeTime   ;

		
		public override void Ping(){
			//parti.Emit(amount);
			trig.outsideTriggerCtrl = false;
			ping.pingable = false;
			trig.triggerable = false;
			trig.triggerCounter = trig.timeToTrigger;
			StartCoroutine(Fader());
		}

		IEnumerator Fader() {
			
			float count = 0;
			while (count < fadeTime) {
				count += Time.deltaTime;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			if (!trig.outsideTriggerCtrl) {
				trig.outsideTriggerCtrl = true;
				ping.pingable = true;
			}
		}

	}
}

//}
