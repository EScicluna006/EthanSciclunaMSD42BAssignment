using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;

    [SerializeField] ObstacleWaves obstacleWaves;

    int waypointIndex = 0;

    void Start()
    {
        waypointsList = obstacleWaves.GetWaypoints();

        transform.position = waypointsList[waypointIndex].transform.position;
    }

    void Update()
    {
        obstacleMove();
    }
    public void SetWaveConfig(ObstacleWaves waveConfigToSet)
    {
        obstacleWaves = waveConfigToSet;
    }

    private void obstacleMove()
    {
        if (waypointIndex < waypointsList.Count)
        {
            var targetPosition = waypointsList[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = obstacleWaves.GetObstacleMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }
}
