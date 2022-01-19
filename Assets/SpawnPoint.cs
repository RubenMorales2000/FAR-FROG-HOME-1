using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform player;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {

        // Choose the player position from somewhere random on the map.
        pos.x = Random.Range(-8, 8);
        pos.y = 1;
        pos.z = Random.Range(-8, 8);

        GameObject.Instantiate(player, pos, player.transform.rotation);
    }
}
