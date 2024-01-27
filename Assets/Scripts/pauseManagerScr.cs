using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseManagerScr : MonoBehaviour
{
    public bool isPaused;
    public InputAction pause;

    public GameObject pauseMenu;

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