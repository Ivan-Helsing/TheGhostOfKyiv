using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] int enemyIncreaser = 0;
    [SerializeField] GameObject putlerMessage;


    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private void Update()
    {
        if (FindObjectsOfType<EnemyPathing>().Length <= 0) { putlerMessage.SetActive(true); FindObjectOfType<SceneLoader>().WaitAndLoadStartMenu(); putlerMessage.SetActive(false); }
    }

    private IEnumerator SpawnAllWaves()
    {
        
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnInRandomPoint(currentWave));
        }
        
    }

    private IEnumerator SpawnInRandomPoint(WaveConfig waveConfig)
    {
        int enemyPerWave = waveConfig.GetNumberOfEnemies() + enemyIncreaser;
        for (int enemyCount = 0; enemyCount < enemyPerWave; enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.LookRotation(Vector3.forward , waveConfig.GetWaypoints()[1].transform.position));
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); 
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }



}
