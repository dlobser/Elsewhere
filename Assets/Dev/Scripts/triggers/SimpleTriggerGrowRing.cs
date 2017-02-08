using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTriggerGrowRing : SimpleTrigger {

    public ON_ObjectPool pool;
    public GameObject poolParent;
    public GameObject container;
    public float pingSpeed;
    GameObject ring;
    Material mat;
    public string channel;

    bool pinged;

    public override void Ping()
    {
        if (ring == null && !pinged) {
            pinged = true;
            StartCoroutine(Animate(ring));
        }
    }

    IEnumerator Animate(GameObject ring)
    {
        ring = pool.PoolInstantiate();
        ring.transform.position = this.transform.position;
        ring.transform.parent = container.transform;
        mat = ring.GetComponent<MeshRenderer>().material;
        float counter = 0;
        Vector4 vec = mat.GetVector(channel);
        while (counter < 1)
        {
            pinged = true;
            counter += Time.deltaTime*pingSpeed;
            vec.Set(counter, vec.y, vec.z, vec.w);
            mat.SetVector(channel, vec);
            if (counter >= 1)
            {
                pool.PoolDestroy(ring);
                ring = null;
                pinged = false;

            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
      
    }
}
