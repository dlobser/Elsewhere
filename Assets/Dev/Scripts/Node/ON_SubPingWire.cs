using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_SubPingWire : ON_SubPing {

    public GameObject pinger;
    List<GameObject> pingers;

    public override void Ping() {
        pingers = new List<GameObject>();
        GameObject p = Instantiate(pinger);
        p.transform.parent = pingContainer.transform;
        p.transform.localPosition = Vector3.zero;
        pingers.Add(p);
        p.transform.localScale = new Vector3(p.transform.localScale.x / scale, p.transform.localScale.y / scale, p.transform.localScale.z / scale);
        StartCoroutine(PingAnimation(p));
    }

    IEnumerator PingAnimation(GameObject pingGeo)
    {
        float counter = 0;
        ON_NodePing nodePing = sibling.GetComponent<ON_NodePing>();
        float dist = Vector3.Distance(this.transform.position, sibling.transform.position);
        while (counter < 1)
        {
            counter += (Time.deltaTime * (speed / dist));
            pingGeo.transform.localPosition = Vector3.Lerp(this.transform.localPosition, sibling.transform.localPosition, (counter / 1) * .5f);
            pingGeo.transform.LookAt(sibling.transform.position);
            pingGeo.transform.localScale = new Vector3(pingGeo.transform.localScale.x, pingGeo.transform.localScale.y, dist * (counter / 1));
            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (nodePing != null)
            nodePing.Ping((int)scale);

        while (counter < 3)
        {
            counter += (Time.deltaTime * (speed / dist));
            pingGeo.transform.localScale = new Vector3(pingGeo.transform.localScale.x * (1 - ((counter - 1) / 2)), pingGeo.transform.localScale.y * (1 - ((counter - 1) / 2)), dist);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(pingGeo);
    }
}
