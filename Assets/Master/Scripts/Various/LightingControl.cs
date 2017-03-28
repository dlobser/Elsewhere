using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightingControl : MonoBehaviour {

	public Color ColorR;
	public Color ColorG;
	public Color ColorB;

	public Material roomMat;

    public GameObject matParent;

	public Material crystalR;
	public Material crystalG;
	public Material crystalB;

    public SpriteRenderer crystalSpriteR;
    public SpriteRenderer crystalSpriteG;
    public SpriteRenderer crystalSpriteB;

    public float spriteBrightness;

    Material mat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		roomMat.SetColor ("_ColorR", ColorR);
		roomMat.SetColor ("_ColorG", ColorG);
		roomMat.SetColor ("_ColorB", ColorB);

        if (matParent != null) {
            for (int i = 0; i < matParent.transform.childCount; i++) {
                mat = matParent.transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial;
                mat.SetColor("_ColorR", ColorR);
                mat.SetColor("_ColorG", ColorG);
                mat.SetColor("_ColorB", ColorB);
            }
        }
		crystalR.color = ColorR*5;
		crystalG.color = ColorG*5;
		crystalB.color = ColorB*5;
        crystalSpriteR.color = ColorR * spriteBrightness;
        crystalSpriteG.color = ColorG * spriteBrightness;
        crystalSpriteB.color = ColorB * spriteBrightness;

    }
}
