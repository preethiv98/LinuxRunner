using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    public GameObject player;
    private GameObject newPlayer;
    public Transform respawnPoint;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SpawnPlayer();
            Destroy(col.gameObject);
        }
    }

    void SpawnPlayer()
    {
        newPlayer = Instantiate(player, respawnPoint.position, respawnPoint.rotation);
        player = newPlayer;
    }
}
