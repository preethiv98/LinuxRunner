using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectivePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject objective;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void HideObjective()
    {
        objective.SetActive(false);
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }
}
