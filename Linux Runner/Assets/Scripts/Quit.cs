using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject objective;

   
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            
        }
        if(!panel.activeSelf)
        {
            if(objective.activeSelf)
            {
                Time.timeScale = 0;
            }
           
        }
      

    }
}
