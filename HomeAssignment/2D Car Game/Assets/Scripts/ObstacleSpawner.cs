using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of Waves
    [SerializeField] List<ObstacleWaves> waveConfigList;

    [SerializeField] bool looping = false;

    //we start from wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);//while (looping == true)
    }

    private IEnumerator SpawnAllEnemiesInWave(ObstacleWaves waveToSpawn)
    {

        for (int enemyCount = 0; enemyCount < waveToSpawn.GetNumberOfObstacles(); enemyCount++)
        {
            //spawn the enemyPrefab from waveToSpawn
            //at the position specified waveToSpawn waypoint[0]
            var newEnemy = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity) as GameObject;

            //select the wave and apply the enemy to it
            newEnemy.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            //wait spawnTime 
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }


    }

    private IEnumerator SpawnAllWaves()
    {
        //loop from starting position to end position in our List
        foreach (ObstacleWaves currentWave in waveConfigList)
        {
            //wait for all enemies in currentWave to spawn before yielding
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
