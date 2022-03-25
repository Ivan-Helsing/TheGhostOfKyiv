using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private const float V = 1.2f;
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] int enemyIncreaser = 0;
    [SerializeField] GameObject putlerMessage;


    private bool messageInstantiated = false;
    private float minEnemySize = 0.6f;
    private float maxEnemySize = 1.4f;


    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private void Update()
    {
        if (FindObjectsOfType<EnemyPathing>().Length <= 0 && !messageInstantiated)
        {
            Instantiate(putlerMessage, transform.position, Quaternion.identity);
            FindObjectOfType<SceneLoader>().WaitAndLoadStartMenu();
            messageInstantiated = true;
        }
    }

    public float RandomSizeScale()
    {
        float randomScaler = Random.Range(minEnemySize, maxEnemySize);
        return randomScaler;
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
                Quaternion.LookRotation(Vector3.forward , waveConfig.GetWaypoints()[1].transform.position), gameObject.transform);
            newEnemy.transform.localScale *= RandomSizeScale();
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); 
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }



}
