using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_SubPing : MonoBehaviour {

    public bool isPlaying { get; set; }
    public float speed { get; set; }
    public float scale { get; set; }
    public ON_Node origin { get; set; }
    public ON_Node sibling { get; set; }
    public GameObject pingContainer { get; set; }
    public virtual void Ping() {}
}
