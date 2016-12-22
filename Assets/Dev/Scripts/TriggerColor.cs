using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColor : TriggerPrewarm
{

    public Color newColor;
    Color oldColor;
    public string channel;
    Material mat;

    public override void Animate(float t)
    {
        mat.SetColor(channel, Color.Lerp(oldColor, newColor, t));
    }

    void Start()
    {
        mat = this.GetComponent<MeshRenderer>().material;
        oldColor = mat.GetColor(channel);
    }


}
