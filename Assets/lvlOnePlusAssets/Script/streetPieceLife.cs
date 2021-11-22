using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class streetPieceLife : MonoBehaviour
{
    private bool hasGenerated;
    public int maxSpawnBatch;
    public Vector3 spawnAreaCenter;
    public float spawnAreaWidth;
    public float spawnAreaLength;
    public float spawnRate;
    public GameObject stick;
    public GameObject cigar;
    public GameObject can;
    private Dictionary<int,List<GameObject>> obstaclesBySpawnCapacity;
    void Start()
    {
        obstaclesBySpawnCapacity = new Dictionary<int, List<GameObject>>();
        obstaclesBySpawnCapacity.Add(1,new List<GameObject>());
        obstaclesBySpawnCapacity.Add(2,new List<GameObject>());
        obstaclesBySpawnCapacity.Add(3,new List<GameObject>());
        obstaclesBySpawnCapacity[1].Add(stick);
        obstaclesBySpawnCapacity[3].Add(can);
        obstaclesBySpawnCapacity[3].Add(cigar);
        spawnRandomObstacles();
        this.hasGenerated = false;
    }

    public void setHasGenerated()
    {
        this.hasGenerated = true;
    }

    public bool getHasGenerated()
    {
        return this.hasGenerated;
    }

    private void spawnRandomObstacles()
    {
        int randomObstacleSize = Random.Range(0,obstaclesBySpawnCapacity.Count);
        switch (randomObstacleSize) {
            case 0:
                spawnBigObstacle();
                return;
            //No hay objetos de dos espacios aun
            //case 1:
            //    return;
            case 2:
                spawnSmallObstacles();
                return;
        }
    }

    private float getRadiusFromCenter(GameObject measuredObject)
    {
        Vector3 size = measuredObject.transform.GetComponent<MeshRenderer>().bounds.size;
        float diameter = Mathf.Max(size.x, size.y, size.z);
        float minSpawnDistance = diameter/2.0f;
        return minSpawnDistance;
    }

    private float getMaxRadiusFromCenterFromObjectList(List<GameObject> measuredObjects)
    {
        float maxSize = 0f;
        float radiusSize;
        foreach(GameObject measuredObject in measuredObjects) {
            radiusSize = getRadiusFromCenter(measuredObject);
            maxSize =  radiusSize > maxSize ? radiusSize : maxSize; 
        }
        return maxSize;
    }

    private void spawnSmallObstacles()
    {
        int batchSpawned = this.maxSpawnBatch;
        List<GameObject> smallObjects = obstaclesBySpawnCapacity[3];
        int numObjects = smallObjects.Count;
        GameObject randomSmallObject;

        float biggestRadiusFromSmallObjects = getMaxRadiusFromCenterFromObjectList(smallObjects);
        float minDistanceBetweenLanes = biggestRadiusFromSmallObjects*2.0f;
        float furtherPieceEnd = this.transform.position.z + spawnAreaCenter.z + spawnAreaLength/2.0f;
        float closerPieceEnd = this.transform.position.z + spawnAreaCenter.z - spawnAreaLength/2.0f;
        float currentLane = furtherPieceEnd;
        float maxLanes = 3;
        while (getOffsetedRangeDistance(getOffsetedRange(currentLane, closerPieceEnd, minDistanceBetweenLanes)) > minDistanceBetweenLanes && maxLanes-- > 0) {
            (float furtherLaneLimit, float closerLaneLimit) laneLimits = getOffsetedRange(currentLane, closerPieceEnd, minDistanceBetweenLanes);
            currentLane = Random.Range(laneLimits.furtherLaneLimit, laneLimits.closerLaneLimit);

            //if(randomBool(this.spawnRate)) creo que true mejor si no es cuadraticamente inferior la posibilidad de spawn
            if (true) {

                float laneHorizontalEndingPoint = spawnAreaCenter.x + spawnAreaWidth/2.0f;
                float laneHorizontalStartingPoint = spawnAreaCenter.x - spawnAreaWidth/2.0f;
                float laneCurrentHorizontalPoint = laneHorizontalStartingPoint;
                float minDistanceBetweenObjectsInSameLane = minDistanceBetweenLanes;
                float maxLaneSpawns = 3;
                float currentLaneSpawns = 0;
                while (getOffsetedRangeDistance(getOffsetedRange(laneCurrentHorizontalPoint, laneHorizontalEndingPoint, minDistanceBetweenObjectsInSameLane)) > minDistanceBetweenObjectsInSameLane && currentLaneSpawns < maxLaneSpawns && batchSpawned > 0) {
                    (float furtherLaneLimit, float closerLaneLimit) inLaneLimits = getOffsetedRange(laneCurrentHorizontalPoint, laneHorizontalEndingPoint, minDistanceBetweenObjectsInSameLane);
                    laneCurrentHorizontalPoint = Random.Range(inLaneLimits.furtherLaneLimit, inLaneLimits.closerLaneLimit);
                    if(randomBool(this.spawnRate)) {
                        randomSmallObject = smallObjects[Random.Range(0,numObjects)];
                        Vector3 spawnPos = new Vector3(laneCurrentHorizontalPoint,randomSmallObject.transform.position.y, currentLane);
                        Vector3 spawnRotEuler = randomSmallObject.transform.rotation.eulerAngles;
                        spawnRotEuler.y = Random.Range(0f,360f);
                        GameObject spawnedObstacle = Instantiate(randomSmallObject, spawnPos, Quaternion.Euler(spawnRotEuler));
                        spawnedObstacle.transform.parent = this.transform;
                        currentLaneSpawns++;
                        batchSpawned--;
                    }
                }
            }
        }

    }

    private void spawnMediumObstacle()
    {
        
    }

    private void spawnBigObstacle()
    {
        if(randomBool(this.spawnRate)) {
            List<GameObject> bigObjects = obstaclesBySpawnCapacity[1];
            int numObjects = bigObjects.Count;
            GameObject randomBigObject = bigObjects[Random.Range(0,numObjects)];
            //float obstacleRadius = getRadiusFromCenter(randomBigObject);
            //float posLeftWall = spawnAreaCenter.x - spawnAreaWidth/2.0f;
            //float leftSpawnableLimit = posLeftWall + obstacleRadius;
            //float posRightWall = spawnAreaCenter.x + spawnAreaWidth/2.0f;
            //float rightSpawnableLimit = posRightWall - obstacleRadius;
            //Lo dejo porque si no igual la funcion lia un poco
            (float leftSpawnableLimit, float rightSpawnableLimit) spawnLimits = getOffsetedRange(spawnAreaCenter.x - spawnAreaWidth/2.0f, spawnAreaCenter.x + spawnAreaWidth/2.0f, getRadiusFromCenter(randomBigObject));

            Vector3 spawnPos = new Vector3(Random.Range(spawnLimits.leftSpawnableLimit, spawnLimits.rightSpawnableLimit),this.transform.position.y,this.transform.position.z);
            Vector3 spawnRotEuler = randomBigObject.transform.rotation.eulerAngles;
            spawnRotEuler.y = Random.Range(0f,360f);
            GameObject spawnedObstacle = Instantiate(randomBigObject, spawnPos, Quaternion.Euler(spawnRotEuler));
            spawnedObstacle.transform.parent = this.transform;
        }
    }

    private (float,float) getOffsetedRange(float val1, float val2, float offsetVal)
    {
        return (Mathf.Max(val1, val2) - offsetVal, Mathf.Min(val1,val2) + offsetVal);
    }

    private float getOffsetedRangeDistance((float,float) range)
    {
        return Mathf.Abs(range.Item1 - range.Item2);
    }

    private bool randomBool(float rate)
    {
        return Random.Range(0.0f, 1.0f) < rate;
    }
}
