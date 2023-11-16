using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Money money;
    public GameObject Turret1Ghost;
    public GameObject Turret1Real;
    public GameObject Turret2Ghost;
    public GameObject Turret2Real;
    public int T1Cost = 100;
    public int T2Cost = 250;
    public string state = "Ready";
    public string turret = "nil";   //will spawn based on turret selected
    private Vector3 pos;

    void Awake()
    {
        money = GameObject.Find("GameMaster").GetComponent<Money>();
    }

    public void PurchaseTurret1()
    {
        //Debug.Log("Purchase Turret 1");
        if (state == "Ready")
        {
            turret = "1";
            state = "MoneyCheck";
        }
    }

    public void PurchaseTurret2()
    {
        //Debug.Log("Purchase Turret 2");
        if (state == "Ready")
        {
            turret = "2";
            state = "MoneyCheck";
        }
    }

    void Update()
    {
        //Debug.Log(money.cash);
        //Debug.Log(state);
        switch (state)
        {
            case "Ready":
                //calculated in PurchaseTurret1()
                break;

            case "MoneyCheck":
                if(money.cash >= T1Cost)
                {
                    if (turret == "1")
                    {
                        Instantiate(Turret1Ghost, new Vector3(0f, 2f, 0f), Quaternion.Euler(0, 0, 0));
                    }
                    else if (turret == "2")
                    {
                        Instantiate(Turret2Ghost, new Vector3(0f, 2f, 0f), Quaternion.Euler(0, 0, 0));
                    }
                    state = "Placement";
                }
                else
                {
                    state = "Ready";
                    //playsound wah
                }
                break;

            case "Placement":
                    //calculated in Node.cs
                break;

            case "Cancel":
                if (turret == "1")
                {
                    Destroy(GameObject.Find("Turret1ghost(Clone)"));
                }
                else if (turret == "2")
                {
                    Destroy(GameObject.Find("Turret2ghost(Clone)"));
                }
                state = "Ready";
                break;

            case "Actualisation":
                if (turret == "1")
                {
                    pos = GameObject.Find("Turret1ghost(Clone)").transform.position;
                    Instantiate(Turret1Real, pos, Quaternion.Euler(0, 2f, 0));
                    Destroy(GameObject.Find("Turret1ghost(Clone)"));
                    money.cash -= T1Cost;
                }
                else if (turret == "2")
                {
                    pos = GameObject.Find("Turret2ghost(Clone)").transform.position;
                    Instantiate(Turret2Real, pos, Quaternion.Euler(0, 2f, 0));
                    Destroy(GameObject.Find("Turret2ghost(Clone)"));
                    money.cash -= T1Cost;
                }
                state = "Ready";
                turret = "nil";
                break;
        }
    }
}