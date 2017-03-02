using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_CopyAllComponents : MonoBehaviour {

    public GameObject sourceGO;
    public GameObject targetGOParent;

	void Start () {
        for (int i = 0; i < targetGOParent.transform.childCount; i++) {
            CopySpecialComponents(sourceGO, targetGOParent.transform.GetChild(i).gameObject);
        }
	}

    private void CopySpecialComponents(GameObject _sourceGO, GameObject _targetGO) {
        foreach (var component in _sourceGO.GetComponents<Component>()) {
            var componentType = component.GetType();
            if (componentType != typeof(Transform) &&
                componentType != typeof(MeshFilter) &&
                componentType != typeof(MeshRenderer)
                ) {
                Debug.Log("Found a component of type " + component.GetType());
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(_targetGO);
                if(componentType == typeof(MeshCollider)) {
                    Mesh mesh = _targetGO.GetComponent<MeshFilter>().mesh;
                    _targetGO.GetComponent<MeshCollider>().sharedMesh = mesh;
                    //_targetGO.GetComponent<Rigidbody>().isKinematic = true;
                }
                Debug.Log("Copied " + component.GetType() + " from " + _sourceGO.name + " to " + _targetGO.name);
            }
        }
    }

}
