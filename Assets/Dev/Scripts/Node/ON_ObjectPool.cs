using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_ObjectPool : MonoBehaviour {

    public GameObject poolContainer;
    public int poolSize;
    public GameObject poolObject;
    public List<GameObject> pool;
    Vector3 scale;

    void Awake () {
        pool = new List<GameObject>();
        scale = poolObject.transform.localScale;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject thisPoolObject = Instantiate(poolObject);
            thisPoolObject.transform.parent = poolContainer.transform;

        }
	}

    public GameObject PoolInstantiate()
    {
        if (poolContainer.transform.childCount == 0)
        {
            GameObject thisPoolObject = Instantiate(poolObject);
            thisPoolObject.transform.parent = poolContainer.transform;
        }

        return poolContainer.transform.GetChild(0).gameObject;
    }

    public void PoolDestroy(GameObject thisPoolObject)
    {
        thisPoolObject.transform.parent = poolContainer.transform;
        thisPoolObject.transform.localScale = scale;
    }
}
