using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerColor : SimpleTrigger {

    public Color newColor;
    public Color oldColor;
    public bool getOldColorFromMaterial = false;
    public string channel;
    public float speed;
    float counter = 0;
    Material mat;
    public bool reverse = false;
    public override void Ping()
    {
        mat = this.GetComponent<MeshRenderer>().material;
        if(getOldColorFromMaterial)
            oldColor = mat.GetColor(channel);
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        
        while (counter < speed)
        {
            counter += Time.deltaTime;
            if(!reverse)
                mat.SetColor(channel,Color.Lerp(oldColor, newColor, counter / speed));
            else
                mat.SetColor(channel, Color.Lerp(newColor, oldColor,  counter / speed));
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
