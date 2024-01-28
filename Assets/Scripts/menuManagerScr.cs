using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuManagerScr : MonoBehaviour
{
    public GameObject credits;
    public GameObject main;
    public AudioSource clickSound;


    private void Start()
    {
        PressBack();
        if (clickSound == null)
        {
            clickSound = GetComponent<AudioSource>();
        }
        clickSound.Stop();
    }
    public void PressQuit()
    {
        Application.Quit();
        clickSound.Play();
    }
    public void PressPlay()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        clickSound.Play();
    }
    public void PressCredits()
    {
        credits.SetActive(true);
        main.SetActive(false);
        clickSound.Play();
    }
    public void PressBack()
    {
        credits.SetActive(false);
        main.SetActive(true);
        clickSound.Play();
    }
}
