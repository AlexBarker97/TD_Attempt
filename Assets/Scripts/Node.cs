using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Renderer rend;
	private Color startColor;
	public GameObject Turret1Ghost;
	public GameObject Turret1Real;
	public bool gndTurret = false;
	private GameObject Old;
	

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseEnter()
	{
		if (rend.gameObject.name == "GndNode(Clone)")
        {
			Instantiate(Turret1Ghost, rend.gameObject.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0, 0, 0));
			Old = rend.gameObject;
			if(Old.name == "GndNode(Clone)")
            {
				Destroy(GameObject.Find("Turret1ghost(Clone)"));
			}
		}
	}

	void OnMouseOver()
	{
		//Debug.Log(GameObject.Find("Shop").GetComponent<Shop>().state);
		//Debug.Log(rend.gameObject.name);
		if ((GameObject.Find("Shop").GetComponent<Shop>().state == 2) & ((rend.gameObject.name == "GndNode(Clone)")|(rend.gameObject.name == "Turret1")))
        {
			if (Input.GetMouseButtonDown(1))
			{
				GameObject.Find("Shop").GetComponent<Shop>().state = 3;
			}
			if (Input.GetMouseButtonDown(0))
			{
				GameObject.Find("Shop").GetComponent<Shop>().state = 4;
			}
		}
	}

	void OnMouseExit()
	{

	}
}