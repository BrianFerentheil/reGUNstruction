using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

public static bool OptionIsEnabled = false;
public GameObject optionMenuUI;

// Update is called once per frame

    public void Enable()
    {
    optionMenuUI.SetActive(false);
    OptionIsEnabled = true;
    }
    public void Disable()
    {
    optionMenuUI.SetActive(true);
    OptionIsEnabled = false;
    }

public AudioMixer audioMixer;

public void SetVolume(float volume)
{
    audioMixer.SetFloat("music", volume);
    audioMixer.SetFloat("sfx", volume);
}
public void SetMusic(float volume)
{
    audioMixer.SetFloat("music", volume);
}
public void SetSfx(float volume)
{
    audioMixer.SetFloat("sfx", volume);
}
}