using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool FreePlay = false;

    public void freePlay()
    {
        FreePlay = true;
        gameObject.SetActive(false);
    }
}