using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    //public int scene;
    // Update is called once per frame
    public Animator anim;
    public GameObject panel;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            anim.SetTrigger("win");
            Invoke("ShowPanel", 3f);

            //SceneManager.LoadScene(scene);
        }
    }

    void ShowPanel()
    {
        panel.SetActive(true);
    }
}
