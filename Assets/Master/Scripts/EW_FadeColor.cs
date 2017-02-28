using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_FadeColor : MonoBehaviour {

    public Color color;
    public float speed;
    Color initColor;
    Material initMat;
    MeshRenderer rend;
    Material mat;

    Color newCol;

    public string channel;
	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        initMat = rend.sharedMaterial;
        initColor = Color.black;// initMat.color;
        mat = rend.material;
        rend.material = mat;
        StartCoroutine(fade());
	}

    IEnumerator fade() {
        float count = 0;

        while (count < 1) {
            Debug.Log(count);
            count += Time.deltaTime * speed;
            newCol = Color.Lerp(color, initColor, count);
            mat.SetColor(channel, newCol);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        rend.material = initMat;
        //this.enabled = false;
    }
	
}
