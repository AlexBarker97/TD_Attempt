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