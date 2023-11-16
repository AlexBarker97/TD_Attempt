using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int cash;
    public Text moneyRemainingText;
    public GameObject gameOverUI;
    bool freePlay = false;

    // Start is called before the first frame update
    void Start()
    {
        cash = gameObject.GetComponent<GameMaster>().startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        freePlay = gameOverUI.GetComponent<GameOver>().FreePlay;
        if (freePlay)
        {
            moneyRemainingText.text = "Free Play Mode";
            cash = 9999999;
        }
        else
        {
            moneyRemainingText.text = cash.ToString();
        }
    }
}