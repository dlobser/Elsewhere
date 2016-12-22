using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetTexture : MonoBehaviour {

    public Vector2 speed;
    Vector2 UV;
    Material mat;
	void Start () {
        mat = this.gameObject.GetComponent<MeshRenderer>().material;
	}
	
	void Update () {
        UV.Set(UV.x += Time.deltaTime * speed.x, UV.y += Time.deltaTime * speed.y);
        mat.SetTextureOffset("_MainTex", UV);
	}
}
