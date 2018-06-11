using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlTintShader : MonoBehaviour {

    MeshRenderer[] renders;
    bool onoff;
    public Texture[] textures;
	// Use this for initialization
	void Start () {
        
	}
	
    void setData(bool on) {
        renders = gameObject.GetComponentsInChildren<MeshRenderer>();
        int w = (int)Mathf.Floor(Random.value * textures.Length);
        for (int i = 0; i < renders.Length; i++) {
            Vector4 oldData = renders[i].material.GetVector("_Data");
            renders[i].material.SetVector("_Data", new Vector4(oldData.x, oldData.y, on ? 1 : 0, oldData.w));
            renders[i].material.SetTexture("_SecondTex", textures[w]);
        }
    }
    void setTexture() {
        renders = gameObject.GetComponentsInChildren<MeshRenderer>();
        int w = (int)Mathf.Floor(Random.value * textures.Length);
        for (int i = 0; i < renders.Length; i++) {
            renders[i].material.SetTexture("_SecondTex", textures[w]);
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.X)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                setTexture();
            }
            else {
                onoff = !onoff;
                Debug.Log(onoff);
                setData(onoff);

            }
        }
    }
}
