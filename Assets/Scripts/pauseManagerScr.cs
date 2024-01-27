using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class pauseManagerScr : MonoBehaviour
{
    public bool isPaused;
    public InputAction pause;

    public GameObject pauseMenu;
    public GameObject mainUI;

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
    }

    public void UnpauseGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        mainUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    void PauseGame()
    {
        isPaused=true;
        pauseMenu.SetActive(true);
        mainUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
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
}
