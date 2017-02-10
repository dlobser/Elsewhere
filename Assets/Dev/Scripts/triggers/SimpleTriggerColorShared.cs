using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerColorShared : SimpleTrigger {

    public Color newColor;
    Color oldColor;
    public string channel;
    public float speed;
    float counter = 0;
    public Material mat;
	bool triggered = false;

	void Start(){
		oldColor = mat.GetColor(channel);
	}

    public override void Ping()
    {
       
		if(!triggered)
        	StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
		triggered = true;
		counter = 0;
        while (counter < speed)
        {
            counter += Time.deltaTime;
            mat.SetColor(channel,Color.Lerp(oldColor, newColor, counter / speed));
            yield return new WaitForSeconds(Time.deltaTime);
        }
		counter = 0;
		StartCoroutine (AnimateBack ());
    }

	IEnumerator AnimateBack()
	{

		while (counter < speed)
		{
			counter += Time.deltaTime;
			mat.SetColor(channel,Color.Lerp(newColor, oldColor, counter / speed));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		triggered = false;
	}
}
