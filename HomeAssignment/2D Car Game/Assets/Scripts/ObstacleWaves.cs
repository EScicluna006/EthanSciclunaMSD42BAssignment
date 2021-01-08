using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class ObstacleWaves : ScriptableObject
{
    //the enemy to spawn
    [SerializeField] GameObject obstaclePrefab;
    //the path on which the wave will move
    [SerializeField] GameObject pathPrefab;
    //time between each Enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //random difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;
    //number of enemies in wave
    [SerializeField] int numberOfObstacles = 5;
    //enemy movement speed
    [SerializeField] float obstacleMoveSpeed = 2f;

    //encapsulation methods
    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different number of waypoints
        var waveWaypoints = new List<Transform>();

        //go into Path Prefab and for each child, add it to the List
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

}
