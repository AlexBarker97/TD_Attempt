using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int cash;
    public Text cashRemainingText;
    public GameObject Turret1;

    void Start()
    {
        cash = GameObject.Find("GameMaster").GetComponent<GameMaster>().startingMoney;
    }

    public void PurchaseTurret1()
    {
        Debug.Log("Purchase Turret 1");
        Instantiate(Turret1, new Vector3(0f,0f,0f), Quaternion.Euler(0, 0, 0));
        cash = cash - 100;
    }

    void Update()
    {
        cashRemainingText.text = cash.ToString();
    }
}