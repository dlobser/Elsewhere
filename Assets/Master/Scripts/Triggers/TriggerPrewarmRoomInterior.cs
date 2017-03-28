using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmRoomInterior : TriggerPrewarm {

    public Texture[] textures;
    public string channelA;
	public string channelB;
	public string floatChannel;
    MeshRenderer rend;
    Material mat;
    public Material sharedMat;
    int prevIndex = 0;

    bool pinged = false;
	bool pingpong = false;

    public override void Animate(float t) {
        if (!pinged) {
            rend = this.GetComponent<MeshRenderer>();
            mat = rend.material;
			mat.SetTexture(channelA, textures[(int)Mathf.Floor(Random.Range(0,textures.Length))]);
            pinged = true;
        }
//        int index = (int)Mathf.Ceil(t * (textures.Length-1));
//        if (prevIndex != index && !pingpong) {
//            mat.SetTexture(channelA, textures[Mathf.Max(0,Mathf.Min(textures.Length - 1, index))]);
//			pingpong = true;
//        }
//		if (prevIndex != index && pingpong) {
//			mat.SetTexture(channelB, textures[Mathf.Max(0,Mathf.Min(textures.Length - 1, index))]);
//			pingpong = false;
//		}
//		if(!pingpong)
//			mat.SetFloat (floatChannel, index - (t * (textures.Length - 1)));
//		else
//			mat.SetFloat (floatChannel, 1-( index - (t * (textures.Length - 1))));
//
		mat.SetFloat (floatChannel, t);

//        prevIndex = index;
    }

    public override void Reset()
    {
        //rend.material = sharedMat;
        //if (textures.Length>0)
        //    mat.SetTexture(channel, textures[0]);

    }

    private void OnApplicationQuit() {
		if(rend!=null && sharedMat!=null)
        	rend.material = sharedMat;
    }

    void Start()
    {
       
    }


}
