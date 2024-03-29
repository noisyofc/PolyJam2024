using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class pauseManagerScr : MonoBehaviour
{
    public bool isPaused;
    public InputAction pause;

    public GameObject pauseMenu;
    public GameObject mainUI;
    public GameObject winScreen;
    public GameObject deathScreen;
    public AudioSource clickSound;

    public float stars = 3;
    public GameObject[] starsUI;
    bool win = false;

    public void Loose()
    {
        isPaused = true;
        mainUI.SetActive(false);
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }

    public void Win()
    {
        isPaused = true;
        winScreen.SetActive(true);
        mainUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnEnable()
    {
        pause.Enable();
    }
    private void OnDisable()
    {
        pause.Disable();
    }

    void Start()
    {
        UnpauseGame();
        UpdateStarUI();
        winScreen.SetActive(false);
        deathScreen.SetActive(false);
        if (clickSound == null)
        {
            clickSound = GetComponent<AudioSource>();
        }
        clickSound.Stop();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        mainUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        clickSound.Play();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        clickSound.Play();
    }

    void PauseGame()
    {
        isPaused=true;
        pauseMenu.SetActive(true);
        mainUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        clickSound.Play();
    }
    private void Update()
    {
        if (!win)
        {
            if (stars < 0) { Loose(); }
            if (pause.WasReleasedThisFrame())
            {
                if (isPaused)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
        UpdateStarUI();
    }

    
    void UpdateStarUI()
    {
        for (int i = 0; i < starsUI.Length; i++)
        {
            starsUI[i].SetActive(i<stars);
        }
    }
}
