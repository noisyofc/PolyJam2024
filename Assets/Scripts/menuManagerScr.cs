using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuManagerScr : MonoBehaviour
{
    public GameObject credits;
    public GameObject main;

    private void Start()
    {
        PressBack();
    }

    public void PressQuit()
    {
        Application.Quit();
    }

    public void PressPlay()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void PressCredits()
    {
        credits.SetActive(true);
        main.SetActive(false);
    }
    public void PressBack()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }
}
