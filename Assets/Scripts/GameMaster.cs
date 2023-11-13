using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject MenuUI;
    public Text wavesSurvivedText;
    public bool gamePaused = false;
    private bool gameEnded;
    private int waves;
    public int startingMoney = 200;
    private int remainingMoney = 200;
    public int startingLives = 5;
    private int remainingLives = 0;

    void Start()
    {
        remainingLives = startingLives;
        remainingMoney = startingMoney;
    }

    void MenuButton()
    {
        gamePaused = true;
        MenuUI.SetActive(true);
    }

    void Update()
    {
        waves = gameObject.GetComponent<WaveSpawner>().wavesSpawned;
        gameEnded = gameObject.GetComponent<Lives>().gameEnded;
        if (!gameEnded)
        {
            wavesSurvivedText.text = (waves-1).ToString();
        }
    }
}