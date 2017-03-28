using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVertexColor : MonoBehaviour {

    public Mesh mesh;
    public Color triggerColor;
    public Color baseColor;
    Color[] colors;
    public float fadeSpeed;

    public void Trigger(int which) {

        colors[which] = triggerColor * Random.ColorHSV(0,1);
        StartCoroutine(returnColor(which));
    }

    IEnumerator returnColor(int which) {
        float count = 0;
        while (count < 1) {
            count += Time.deltaTime * fadeSpeed;
            colors = mesh.colors;
            colors[which] = Color.Lerp(triggerColor, baseColor, count / 1);
            mesh.colors = colors;
            yield return new WaitForSeconds(Time.deltaTime) ;
        }
    }

	void Start () {
        colors = new Color[mesh.vertices.Length];
        for (int i = 0; i < colors.Length; i++) {
            colors[i] = baseColor;
        }
        mesh.colors = colors;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
