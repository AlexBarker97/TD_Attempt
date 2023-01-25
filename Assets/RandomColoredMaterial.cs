using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColoredMaterial : MonoBehaviour
{

    void Start()
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        //Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax)
        Color newColor = Random.ColorHSV(0.3f,0.3f, 0.8f,1.0f, 0.35f,0.5f);
        Debug.Log(newColor);
        generatedMaterial.SetColor("_Color", newColor);
        gameObject.GetComponent<MeshRenderer>().material = generatedMaterial;
    }
}