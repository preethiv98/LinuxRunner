using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
   
    //public GameObject[] button;
    public Animator anim;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.Play("Wall_go_down", 0);
        }
    }
}
