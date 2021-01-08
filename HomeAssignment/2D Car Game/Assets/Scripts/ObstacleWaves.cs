using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class ObstacleWaves : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfObstacles = 5;
    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

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
