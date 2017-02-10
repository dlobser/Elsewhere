using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideHexCity : SimpleTrigger {

	public float speed;
	public float amount;

	List<Vector3> initialPositions;
	List<Vector3> currentPositions;
	List<Vector3> newPositions;
	List<float> randomSpeeds;

	public bool trigger;
	bool triggerable = true;

	// Use this for initialization
	void Start () {
		
		initialPositions = new List<Vector3> ();
		newPositions = new List<Vector3> ();
		currentPositions = new List<Vector3> ();
		randomSpeeds = new List<float> ();

		for (int i = 0; i < this.transform.childCount; i++) {
			initialPositions.Add (this.transform.GetChild (i).transform.localPosition);
		}
	}

	void Update(){
		if (trigger) {
			Ping ();
			trigger = false;
		}
	}

	public override void Ping(){
		if (triggerable) {
			triggerable = false;
			StopCoroutine (Animate ());
			newPositions.Clear ();
			currentPositions.Clear ();
			randomSpeeds.Clear ();
			float rando = Random.value;
			for (int i = 0; i < this.transform.childCount; i++) {
				newPositions.Add (initialPositions [i] + new Vector3 (0, rando * amount, 0));
				currentPositions.Add (this.transform.GetChild (i).transform.localPosition);
				randomSpeeds.Add (Random.Range (1, 5));
			}
			StartCoroutine (Animate ());
		}
	}

	IEnumerator Animate()
	{
		float count = 0;
		while (count < 1) {
			float diff = Vector3.Distance (currentPositions [0], newPositions [0]);
			count += Time.deltaTime * (speed/diff);
			for (int i = 0; i < this.transform.childCount; i++) {
				
				this.transform.GetChild (i).transform.localPosition = Vector3.Lerp (currentPositions [i], newPositions [i],Mathf.Clamp( (count*randomSpeeds[i]),0,1));
			}
			yield return new WaitForSeconds (Time.deltaTime);
		}
		triggerable = true;
	}

}