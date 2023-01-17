using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    Enemy enemy;
    public int lives;
    public Text livesRemainingText;
    [SerializeField] GameObject enemyInstance;

    // Awake is called just before Start
    void Awake()
    {
        enemy = enemyInstance.GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = 100;
    }

    // Update is called once per frame
    void Update()
    {
        livesRemainingText.text = lives.ToString();
    }
}