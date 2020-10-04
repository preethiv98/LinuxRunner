using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{

    [SerializeField]
    private GameObject instruction;

    void Start()
    {
       // Time.timeScale = 0;
    }

    public void HideObjective()
    {
        instruction.SetActive(true);
        //Time.timeScale = 1;
    }

    public void ExitObjective()
    {
        instruction.SetActive(false);
       // Time.timeScale = 0;
    }
}
