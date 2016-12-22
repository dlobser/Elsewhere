using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_NodePing : MonoBehaviour {

    public float timeToReset { get; set; }
    public float pingSpeed { get; set; }

    public bool PingSiblings;
    public bool pinged { get; set; }
    public float resetTimer { get; set; }
    public GameObject pingContainer;
    public virtual void Init() { }
    public virtual void Ping(int input) { }
    public virtual void Ping() { }

}
