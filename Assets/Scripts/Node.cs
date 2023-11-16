using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Renderer rend;
	private Color startColor;
	public GameObject Turret1Ghost;
	public GameObject Turret1Real;
    public GameObject Turret2Ghost;
    public GameObject Turret2Real;
    public bool gndTurret = false;
	private GameObject Old;
	

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
    }

	void OnMouseEnter()
	{
		//Debug.Log(rend.material.color);
		rend.material.SetColor("_Color", rend.material.color+ new Color(0.3f, 0.3f, 0.3f, 0f));
        if (rend.gameObject.name == "GndNode(Clone)")
        {
			Debug.Log(GameObject.Find("Shop").GetComponent<Shop>().turret);
            if (GameObject.Find("Shop").GetComponent<Shop>().turret == "1")
			{
                Instantiate(Turret1Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
                Old = rend.gameObject;
                if (Old.name == "GndNode(Clone)")
                {
                    Destroy(GameObject.Find("Turret1ghost(Clone)"));
                }
            } else if (GameObject.Find("Shop").GetComponent<Shop>().turret == "2")
			{
                Instantiate(Turret2Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
                Old = rend.gameObject;
                if (Old.name == "GndNode(Clone)")
                {
                    Destroy(GameObject.Find("Turret2ghost(Clone)"));
                }
            }
        }
	}

	void OnMouseOver()
	{
		if ((GameObject.Find("Shop").GetComponent<Shop>().state == "Placement") & ((rend.gameObject.name == "GndNode(Clone)")|(rend.gameObject.name == "Turret1(Clone)")|(rend.gameObject.name == "Turret2(Clone)")))
        {
			if (Input.GetMouseButtonDown(1))
			{
				GameObject.Find("Shop").GetComponent<Shop>().state = "Cancel";
			}
			if (Input.GetMouseButtonDown(0))
			{
				GameObject.Find("Shop").GetComponent<Shop>().state = "Actualisation";
			}
		}
	}

	void OnMouseExit()
	{
        rend.material.SetColor("_Color", rend.material.color - new Color(0.3f, 0.3f, 0.3f, 0f));
    }
}