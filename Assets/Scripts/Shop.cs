using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Money money;
    public GameObject Turret1Ghost;
    public GameObject Turret1Real;
    public int T1Cost = 100;
    public int state = 0;
    public string turret = "nil";   //will spawn based on turret selected
    private Vector3 pos;

    void Awake()
    {
        money = GameObject.Find("GameMaster").GetComponent<Money>();
    }

    public void PurchaseTurret1()
    {
        //Debug.Log("Purchase Turret 1");
        if (state == 0)
        {
            state = 1;
        }
    }

    void Update()
    {
        //Debug.Log(state);
        switch (state)
        {
            case 0:
                //calculated in PurchaseTurret1()
                break;
            case 1:
                if(Money.money >= T1Cost)
                {
                    Instantiate(Turret1Ghost, new Vector3(0f, 0f, 0f), Quaternion.Euler(0, 0, 0));
                    state = 2;
                }
                else
                {
                    state = 0;
                    //playsound wah
                }
                break;
            case 2:
                    //calculated in Node.cs
                break;
            case 3:
                Destroy(GameObject.Find("Turret1ghost(Clone)"));
                state = 0;
                break;
            case 4:
                pos = GameObject.Find("Turret1ghost(Clone)").transform.position;
                Instantiate(Turret1Real, pos, Quaternion.Euler(0, 0, 0));
                Destroy(GameObject.Find("Turret1ghost(Clone)"));
                Money.money -= T1Cost;
                state = 0;
                break;
        }
    }
}