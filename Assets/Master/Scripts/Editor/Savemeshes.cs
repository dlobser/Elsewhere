using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Savemeshes : MonoBehaviour {

    static string file = "Assets/WeldedMesh";//.asset";
	static Mesh mesh;
	static Mesh weldedMesh;

	[MenuItem("ON/SaveChildMeshes")]

	static void weld()
	{
        for (int i = 0; i < Selection.activeGameObject.transform.childCount; i++) {
            mesh = Selection.activeGameObject.transform.GetChild(i).gameObject.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, file +"_"+i+".asset");
            AssetDatabase.SaveAssets();
        }
		
	}

}
