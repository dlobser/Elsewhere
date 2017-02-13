using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmSwapTextures : TriggerPrewarm {

    public Texture[] textures;
    public string channel;
    MeshRenderer rend;
    Material mat;
    public Material sharedMat;
    int prevIndex = 0;

    bool pinged = false;

    public override void Animate(float t) {
        if (!pinged) {
            rend = this.GetComponent<MeshRenderer>();
            mat = rend.material;
            pinged = true;
        }
        int index = (int)Mathf.Ceil(t * (textures.Length-1));
        if (prevIndex != index) {
            mat.SetTexture(channel, textures[Mathf.Max(0,Mathf.Min(textures.Length - 1, index))]);
        }
        prevIndex = index;
    }

    public override void Reset()
    {
        //rend.material = sharedMat;
        //if (textures.Length>0)
        //    mat.SetTexture(channel, textures[0]);

    }

    private void OnApplicationQuit() {
        rend.material = sharedMat;
    }

    void Start()
    {
       
    }


}
