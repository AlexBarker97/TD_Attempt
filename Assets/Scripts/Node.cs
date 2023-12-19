using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    Money money;
    public Color hoverColor;
	private Renderer rend;
	public Color startColor;
	public GameObject Turret1Ghost;
	public GameObject Turret1Real;
    public GameObject Turret2Ghost;
    public GameObject Turret2Real;
    public GameObject Turret3Ghost;
    public GameObject Turret3Real;
    public GameObject GndNode;
    public GameObject MontNode;
    private int swampClearCost = 1000;
    private int montClearCost = 500;
    private int forestClearCost = 250;

    public bool selected = false;
    public string place;
    public bool gndTurret = false;
	private GameObject Old;
    private Transform ObjParent;
    public string ObjName;
    public Vector3 ObjPos;

    void Awake()
    {
        money = GameObject.Find("GameMaster").GetComponent<Money>();
    }

    void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
    }

	void OnMouseEnter()
	{
        if (!selected)
        {
            if (GameObject.Find("Shop").GetComponent<Shop>().excavateToggle == true)
            {
                rend.material.SetColor("_Color", startColor + new Color(0.65f, -0.25f, -0.25f, 0f));
            }
            else
            {
                rend.material.SetColor("_Color", startColor + new Color(0.3f, 0.3f, 0.3f, 0f));
            }
        }
        place = GameObject.Find("Shop").GetComponent<Shop>().turret;

        if (rend.gameObject.name == "GndNode(Clone)")
        {
            switch (place)
            {
                case "1":
                    Instantiate(Turret1Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
                    Old = rend.gameObject;
                    if (Old.name == "GndNode(Clone)")
                    {
                        Destroy(GameObject.Find("Turret1ghost(Clone)"));
                    }
                    break;

                case "2":
                    Instantiate(Turret2Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
                    Old = rend.gameObject;
                    if (Old.name == "GndNode(Clone)")
                    {
                        Destroy(GameObject.Find("Turret2ghost(Clone)"));
                    }
                    break;

                case "3":
                    Instantiate(Turret3Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
                    Old = rend.gameObject;
                    if (Old.name == "GndNode(Clone)")
                    {
                        Destroy(GameObject.Find("Turret3ghost(Clone)"));
                    }
                    break;

                case "nil":
                    // code nil
                    break;
            }
        }
	}

	void OnMouseOver()
	{
        place = GameObject.Find("Shop").GetComponent<Shop>().turret;
        ObjName = rend.gameObject.name;
        ObjPos = rend.gameObject.transform.position;
        ObjParent = rend.gameObject.transform.parent;

        if ((GameObject.Find("Shop").GetComponent<Shop>().state == "Ready") & (place == "nil"))
        {
            if (Input.GetMouseButtonDown(0)) // leftclick
            {
                //Debug.Log("left");
                //Debug.Log(ObjName);
                if (GameObject.Find("Shop").GetComponent<Shop>().excavateToggle == true)
                {
                    switch (ObjName)
                    {
                        case "Swamp(Clone)":
                            if (money.cash >= swampClearCost)
                            {
                                money.cash -= swampClearCost;
                                Instantiate(GndNode, ObjPos + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0), GameObject.Find("Nodes").transform);
                                Destroy(rend.gameObject);
                            }
                            else
                            {
                                //wah
                            }
                            break;

                        case "Mountain(Clone)":
                            if (money.cash >= montClearCost)
                            {
                                money.cash -= montClearCost;
                                Instantiate(GndNode, ObjPos + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.Find("Nodes").transform);
                                Destroy(rend.gameObject);
                            }
                            else
                            {
                                //wah
                            }
                            break;

                        case "Forest(Clone)":
                            if (money.cash >= forestClearCost)
                            {
                                money.cash -= forestClearCost;
                                Instantiate(GndNode, ObjPos + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.Find("Nodes").transform);
                                Destroy(rend.gameObject);
                            }
                            else
                            {
                                //wah
                            }
                            break;
                    }
                }
                else
                {
                    if(ObjParent != GameObject.Find("Nodes").transform)
                    {
                        if(ObjParent.name == "Turret1(Clone)")
                        {
                            GameObject.Find("Shop").GetComponent<Shop>().UpgradeTurret1(ObjParent, "browse");
                            rend.gameObject.transform.GetComponent<Node>().selected = true;
                            rend.gameObject.tag = "Selected";
                            rend.material.SetColor("_Color", new Color(0.75f, 0.85f, 0.75f, 0f));
                        }
                        if (ObjParent.name == "Turret2(Clone)")
                        {
                            GameObject.Find("Shop").GetComponent<Shop>().UpgradeTurret2(ObjParent, "browse");
                        }
                        if (ObjParent.name == "Turret3(Clone)")
                        {
                            GameObject.Find("Shop").GetComponent<Shop>().UpgradeTurret3(ObjParent, "browse");
                        }
                    }
                }
                
                if (Input.GetMouseButtonDown(1)) // rightclick
                {
                    Debug.Log("right");
                    //Debug.Log(ObjName);
                }
            }
        }

        if ((GameObject.Find("Shop").GetComponent<Shop>().state == "Placement") & (ObjName == "GndNode(Clone)"))
        {
            if (Input.GetMouseButtonDown(0)) // leftclick
            {
                GameObject.Find("Shop").GetComponent<Shop>().state = "Actualisation";
                Destroy(rend.gameObject);
            }
		}
	}

	void OnMouseExit()
	{
        if (!selected)
        {
            rend.material.SetColor("_Color", startColor);
        }
    }
}