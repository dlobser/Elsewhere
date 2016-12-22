using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerColor : SimpleTrigger {

    public Color newColor;
    Color oldColor;
    public string channel;
    public float speed;
    float counter = 0;
    Material mat;

    public override void Ping()
    {
        mat = this.GetComponent<MeshRenderer>().material;
        oldColor = mat.GetColor(channel);
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        
        while (counter < speed)
        {
            counter += Time.deltaTime;
            mat.SetColor(channel,Color.Lerp(oldColor, newColor, counter / speed));
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
