using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    private float gametime;
    private float initialGametime = -10f;
    public int timeBetweenWaves = 5;
    public Text waveCountdownText;
    private int waveIndex = 0;
    private int wavesSpawned = 0;
    private float nextWaveSpawnTime;
    GameObject spawnPoint;

    void Start()
    {
        gametime = initialGametime;
        spawnPoint = GameObject.Find("SpawnPoint(Clone)");
    }

    private void Update()
    {
        nextWaveSpawnTime = Mathf.Floor(waveIndex) * timeBetweenWaves;
        spawnPoint = GameObject.Find("SpawnPoint(Clone)");

        if (gametime >= (nextWaveSpawnTime - 0.3f))
        {
            waveIndex++;
            if (waveIndex >= wavesSpawned)
            {
                StartCoroutine(SpawnWave(spawnPoint));
                wavesSpawned++;
            }
        }

        gametime += Time.deltaTime;
        waveCountdownText.text = Mathf.Round(Mathf.Abs(gametime)).ToString();
    }

    IEnumerator SpawnWave(GameObject spawnPoint)
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy(spawnPoint);
            yield return new WaitForSeconds(0.25f);
        }
    }

    void SpawnEnemy(GameObject spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}