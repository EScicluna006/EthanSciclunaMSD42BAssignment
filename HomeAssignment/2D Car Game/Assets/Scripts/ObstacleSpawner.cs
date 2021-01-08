using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] List<ObstacleWaves> waveConfigList;

    [SerializeField] bool looping = false;


    int startingWave = 0;


    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllEnemiesInWave(ObstacleWaves waveToSpawn)
    {

        for (int enemyCount = 0; enemyCount < waveToSpawn.GetNumberOfObstacles(); enemyCount++)
        {

            var newEnemy = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity) as GameObject;


            newEnemy.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }


    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (ObstacleWaves currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    void Update()
    {

    }
}
