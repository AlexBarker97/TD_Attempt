using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;
    private float gametime;
    private float initialGametime = -5f;
    private int timeBetweenSpawns = 10;
    public Text waveCountdownText;
    private int waveIndex = 0;
    public int wavesSpawned = 0;
    private float nextSpawnTime;
    GameObject spawnPoint;

    int[,] waveSpawns = { 
        {0, 0},     // wave 0 (non existant)
        {1, 1},     // wave 1
        {1, 2},     // wave 2
        {1, 3},     // wave 3
        {2, 1},     // wave 4
        {2, 2},     // wave 5
        {1, 6},     // wave 6
        {2, 4},     // wave 7
        {1, 8},     // wave 8
        {2, 5},     // wave 9
        {1, 10},    // wave 10
        {2, 6},     // wave 11
        {3, 4},     // wave 12
        {3, 6},     // wave 13
        {2, 8},     // wave 14
        {3, 12},    // wave 15
        {3, 15},    // wave 16
        {1, 25},    // wave 17
        {1, 30},    // wave 18
        {2, 20},    // wave 19
        {3, 30}     // wave 20
    };

    void Start()
    {
        gametime = initialGametime;
        spawnPoint = GameObject.Find("SpawnPoint(Clone)");
    }

    private void Update()
    {
        nextSpawnTime = Mathf.Floor(waveIndex) * timeBetweenSpawns;
        spawnPoint = GameObject.Find("SpawnPoint(Clone)");

        if (gametime >= (nextSpawnTime - 0.3f))
        {
            if (waveIndex >= wavesSpawned)
            {
                Debug.Log("Waves: " + (waveIndex+1) + "/" + (waveSpawns.GetLength(0) - 1));

                waveIndex++;
                StartCoroutine(SpawnWave(spawnPoint));
                wavesSpawned++;
            }
        }
        gametime += Time.deltaTime;
        waveCountdownText.text = Mathf.Round(Mathf.Abs(gametime)).ToString();
    }

    IEnumerator SpawnWave(GameObject spawnPoint)
    {
        if (waveSpawns[waveIndex, 0] == 1)
        {
            for (int i = 0; i < waveSpawns[waveIndex, 1]; i++)
            {
                SpawnEnemy(spawnPoint);
                yield return new WaitForSeconds(0.2f);
            }
        }
        if (waveSpawns[waveIndex, 0] == 2)
        {
            for (int i = 0; i < waveSpawns[waveIndex, 1]; i++)
            {
                SpawnEnemy2(spawnPoint);
                yield return new WaitForSeconds(0.4f);
            }
        }
        if (waveSpawns[waveIndex, 0] == 3)
        {
            for (int i = 0; i < waveSpawns[waveIndex, 1]; i++)
            {
                SpawnEnemy3(spawnPoint);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    void SpawnEnemy(GameObject spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.Find("Enemies").transform);
    }
    void SpawnEnemy2(GameObject spawnPoint)
    {
        Instantiate(enemyPrefab2, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.Find("Enemies").transform);
    }
    void SpawnEnemy3(GameObject spawnPoint)
    {
        Instantiate(enemyPrefab3, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.Find("Enemies").transform);
    }
}