using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComida : MonoBehaviour
{
    public GameObject comida;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public int maxComida = 5;
    int comidaCount;

    // Use this for initialization
    void Start()
    {
        comidaCount = 0;


            InvokeRepeating("Spawn", spawnTime, spawnTime);

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        

    }

    void Spawn()
    {
        if (comidaCount < maxComida)
        {
            spawnPosition.x = Random.Range(-5, 135);
            spawnPosition.y = 0.5f;
            spawnPosition.z = Random.Range(-15, 70);

            Instantiate(comida, spawnPosition, Quaternion.identity);

            comidaCount++;
        }
    }
}
