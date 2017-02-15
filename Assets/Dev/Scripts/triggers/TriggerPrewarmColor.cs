using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmColor : TriggerPrewarm {

    public Color newColor;
    Color oldColor;
    public string channel;
    public MeshRenderer rend;
    Material mat;
    Material sharedMat;

	public float power = 1f;

    public bool getRendererFromObject;

    public override void Animate(float t) {
        mat = rend.material;
        mat.SetColor(channel, Color.Lerp(oldColor, newColor, Mathf.Pow(t,power)));
    }

    public override void Reset()
    {
        mat = sharedMat;
    }

    void Start()
    {
        if (getRendererFromObject)
            rend = GetComponent<MeshRenderer>();
        sharedMat = rend.sharedMaterial;
        oldColor = sharedMat.GetColor(channel);
    }


}
