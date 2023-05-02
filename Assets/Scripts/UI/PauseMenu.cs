using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    public EventSystem eventSystem;
    public GameObject retryMenu;
    public GameObject retryButton;
    
    private void Update() {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (Time.timeScale == 0)
            Resume();
        else
            Pause();
    }
    
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    
    public void DeathCoroutine() => StartCoroutine(AwakenRestartUI());
    
    private IEnumerator AwakenRestartUI() {
        eventSystem.SetSelectedGameObject(retryButton);
        while (Time.timeScale > 0.01f) {
            Time.timeScale -= 0.02f;
            // Debug.Log(Time.timeScale);
            // Debug.Log(Time.timeScale > 0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
            // yield return null;
        }
        Time.timeScale = 0f;
        // Debug.Log("Stopped");
        retryMenu.SetActive(true);
        // Debug.Log("Awakened");
    }
}
