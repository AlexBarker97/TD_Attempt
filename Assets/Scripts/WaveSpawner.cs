using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    private float gametime = -2f;
    public int timeBetweenWaves = 1;
    public Text waveCountdownText;
    private int waveIndex = 0;
    private int wavesSpawned = 0;
    private float nextWaveSpawnTime;
    private void Update()
    {
        nextWaveSpawnTime = Mathf.Floor(waveIndex) * timeBetweenWaves;

        if (gametime > nextWaveSpawnTime)
        {
            waveIndex++;
            if (waveIndex >= wavesSpawned)
            {
                StartCoroutine(SpawnWave());
                wavesSpawned++;
            }
        }

        gametime += Time.deltaTime;
        waveCountdownText.text = Mathf.Round(Mathf.Abs(gametime)).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
