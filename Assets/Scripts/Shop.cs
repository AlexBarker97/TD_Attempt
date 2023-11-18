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
    public GameObject Turret3Ghost;
    public GameObject Turret3Real;
    public int T1Cost = 100;
    public int T2Cost = 100;
    public int T3Cost = 100;
    public string state = "Ready";
    public string turret = "nil";   //will spawn based on turret selected
    public bool excavateToggle = false;
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

    public void PurchaseTurret3()
    {
        //Debug.Log("Purchase Turret 3");
        if (state == "Ready")
        {
            turret = "3";
            state = "MoneyCheck";
        }
    }

    public void ExcavateToggle()
    {
        if (excavateToggle == false)
        {
            excavateToggle = true;
            return;
        }
        if (excavateToggle == true)
        {
            excavateToggle = false;
            return;
        }
    }

    void Update()
    {
        //Debug.Log(money.cash);
        //Debug.Log(state);
        if (Input.GetMouseButtonDown(1)) // rightclick
        {
            GameObject.Find("Shop").GetComponent<Shop>().state = "Cancel";
        }
        switch (state)
        {
            case "Ready":
                //calculated in PurchaseTurret1()
                break;

            case "MoneyCheck":
                if(money.cash >= T1Cost & turret == "1")
                {
                    Instantiate(Turret1Ghost, new Vector3(0f, 2f, 0f), Quaternion.Euler(0, 0, 0));
                    state = "Placement";
                }
                else if (money.cash >= T2Cost & turret == "2")
                {
                    Instantiate(Turret2Ghost, new Vector3(0f, 2f, 0f), Quaternion.Euler(0, 0, 0));
                    state = "Placement";
                }
                else if (money.cash >= T3Cost & turret == "3")
                {
                    Instantiate(Turret3Ghost, new Vector3(0f, 2f, 0f), Quaternion.Euler(0, 0, 0));
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
                else if (turret == "3")
                {
                    Destroy(GameObject.Find("Turret3ghost(Clone)"));
                }
                state = "Ready";
                break;

            case "Actualisation":
                if (turret == "1")
                {
                    pos = GameObject.Find("Turret1ghost(Clone)").transform.position;
                    Instantiate(Turret1Real, pos, Quaternion.Euler(0, 0, 0), GameObject.Find("Turrets").transform);
                    Destroy(GameObject.Find("Turret1ghost(Clone)"));
                    money.cash -= T1Cost;
                }
                else if (turret == "2")
                {
                    pos = GameObject.Find("Turret2ghost(Clone)").transform.position;
                    Instantiate(Turret2Real, pos, Quaternion.Euler(0, 0, 0), GameObject.Find("Turrets").transform);
                    Destroy(GameObject.Find("Turret2ghost(Clone)"));
                    money.cash -= T2Cost;
                }
                else if (turret == "3")
                {
                    pos = GameObject.Find("Turret3ghost(Clone)").transform.position;
                    Instantiate(Turret3Real, pos + new Vector3(0,-0.5f,0), Quaternion.Euler(0, 0, 0), GameObject.Find("Turrets").transform);
                    Destroy(GameObject.Find("Turret3ghost(Clone)"));
                    money.cash -= T3Cost;
                }
                state = "Ready";
                turret = "nil";
                break;
        }
    }
}