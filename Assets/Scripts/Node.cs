using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Renderer rend;
	private Color startColor;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseEnter()
	{
		rend.material.color = Color.white;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

}