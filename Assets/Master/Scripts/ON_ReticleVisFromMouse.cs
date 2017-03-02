using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_ReticleVisFromMouse : MonoBehaviour {

    public ON_MouseInteraction mouse;
    public SpriteRenderer sprite;
    float alpha;
    Color col;
    public float maxAlpha = 1;
    Vector3 prevMouse;
	// Use this for initialization
	void Start () {
        col = sprite.color;
	}
	
	// Update is called once per frame
	void Update () {
        float dist;
        if(!mouse.hitPosition.Equals(Vector3.zero) && mouse.hitObject.GetComponent<EW_DontLaserMe>()==null)
            dist = Mathf.Max(.3f, Vector3.Distance(prevMouse, mouse.hitPosition));
        else
            dist = 0;
        alpha += alpha * 100;
        alpha += dist;
        alpha /= 102;
        col.a = alpha;
        if(sprite!=null)
            sprite.color = col;
        prevMouse = mouse.hitPosition;
	}
}
