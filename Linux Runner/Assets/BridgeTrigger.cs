using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{

    //public GameObject[] button;
    public Animator anim;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Bridge down!");
            anim.Play("bridge_down", 0);
        }
    }
}
