using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComida : MonoBehaviour
{
    public GameObject comida;           
    public GameObject enemigo;
    public float spawnTime = 6f;         
    private Vector3 spawnPosition;
    public int maxComida = 5;
    int comidaCount;
    public int maxEnemigo = 2;
    int enemigoCount;

    // Use this for initialization
    void Start()
    {
        comidaCount = 0;
        enemigoCount = 0;

        InvokeRepeating("SpawnFood", spawnTime, spawnTime);
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);

    }

    void SpawnFood()
    {
        if (comidaCount < maxComida)
        {
            spawnPosition.x = Random.Range(-100, 240);
            spawnPosition.y = 0.5f;
            spawnPosition.z = Random.Range(-240, 100);

            Instantiate(comida, spawnPosition, Quaternion.identity);

            comidaCount++;
        }
    }

    void SpawnEnemy()
    {
        if (enemigoCount < maxEnemigo)
        {
            spawnPosition.x = Random.Range(-100, 240);
            spawnPosition.y = 0.5f;
            spawnPosition.z = Random.Range(-240, 100);

            Instantiate(enemigo, spawnPosition, Quaternion.identity);

            enemigoCount++;
        }
    }
}
