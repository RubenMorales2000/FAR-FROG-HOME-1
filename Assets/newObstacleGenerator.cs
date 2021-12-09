using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacleSetups;
    public GameObject player;
    public int howManyAhead;
    public float distanceBetweenObstacles;
    public float generationDistance;
    private float currentGenerationPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        currentGenerationPoint = player.transform.position.x - distanceBetweenObstacles;
        for(int i = 0; i < howManyAhead; i++) {
            spawnRandomObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(currentGenerationPoint) - Mathf.Abs(player.transform.position.x) <= generationDistance) {
            for(int i = 0; i < howManyAhead; i++) {
                spawnRandomObstacle();
            }
        }
    }

    private void spawnRandomObstacle()
    {
        GameObject obstacleToSpawn = getRandomObstacle();
        obstacleToSpawn.tag = "obstaculo";
        Vector3 spawnPos = new Vector3(currentGenerationPoint, obstacleToSpawn.transform.position.y, obstacleToSpawn.transform.position.z);
        Instantiate(obstacleToSpawn, spawnPos, obstacleToSpawn.transform.rotation);
        currentGenerationPoint -= distanceBetweenObstacles;
    }

    private GameObject getRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacleSetups.Length);
        return obstacleSetups[randomIndex];
    }
}
