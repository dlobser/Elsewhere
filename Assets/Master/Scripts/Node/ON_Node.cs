using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_Node : MonoBehaviour {

    public List<ON_Node> siblings;
    List<int> siblingIndices;
    public GameObject displayGeometry;
    public GameObject display { get; set; }
    public ON_NodePing[] nodePings { get; set; }

    public float pingSpeed;
    public float timeToReset;
    public int maxPingAge;
	public bool ping { get; set; }

	public int id { get; set; }

    void Awake () {
        siblings = new List<ON_Node>();
        siblingIndices = new List<int>();
        nodePings = GetComponents<ON_NodePing>();
	}

    public void Animate()
    {
        if (ping){
            Ping(1);
            ping = false;
        }
    }

    public bool NodePingsAreActive() {
        bool running = false;
        if (nodePings!=null) { 
            for (int i = 0; i < nodePings.Length; i++) {
                if (nodePings[i].pinged)
                    running = true;
            }
        }
        return running;
    }

    public void Ping()
    {
        for (int i = 0; i < nodePings.Length; i++){
            nodePings[i].Ping();
        }
    }


    public void Ping(int age)
    {
        for (int i = 0; i < nodePings.Length; i++){
            nodePings[i].Ping(age);
        }
    }

    public void Init(Vector3 pos)
    {
        if(displayGeometry!=null)
        {
            display = Instantiate(displayGeometry);

            ON_Display disp;
            if (display.GetComponent<ON_Display>()==null)
                disp = display.AddComponent<ON_Display>();
            else
                disp = display.GetComponent<ON_Display>();
            disp.connectedNode = this;

            display.transform.parent = this.transform;
            display.transform.localPosition = Vector3.zero;
        }
        this.transform.localPosition = pos;
    }

    public void AddSibling(List<ON_Node> nodes, int index)
    {
        bool alreadyIndexed = false;
        for (int i = 0; i < siblingIndices.Count; i++)
        {
            if(index == siblingIndices[i])
            {
                alreadyIndexed = true;
                break;
            }
        }
        if (!alreadyIndexed)
        {
            siblingIndices.Add(index);
            siblings.Add(nodes[index]);
        }
    }

}
