using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    Enemy enemy;
    public int lives;
    public Text livesRemainingText;
    public GameObject gameOverUI;
    public bool gameEnded;
    [SerializeField] GameObject enemyInstance;
    bool freePlay = false;

    // Awake is called just before Start
    void Awake()
    {
        enemy = enemyInstance.GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        lives = gameObject.GetComponent<GameMaster>().startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        freePlay = gameOverUI.GetComponent<GameOver>().FreePlay;
        if ((lives <= 0) & (freePlay == false))
        {
            EndGame();
        }
        if (freePlay)
        {
            livesRemainingText.text = "Free Play Mode";
        }
        else
        {
            livesRemainingText.text = lives.ToString();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}