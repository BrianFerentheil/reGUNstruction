using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject crafting;
    public GameObject option;
    public GameObject pause;
    public GameObject inGameCanvas;
    public GameObject player;
    public GameObject gunStatCanvas;
    public GameObject ammoCanvas;
    public GameObject scoreCanvas;
    GunRotation[] rotators;
    TheMachine theMachine;

    UnityStandardAssets.Characters.FirstPerson.MouseLook mLook;

    public void UpdateRotators()
    {
        rotators = Resources.FindObjectsOfTypeAll<GunRotation>();
    }

    private void Start()
    {
        //Made public static reference to use state machine access instead, assigning a reference is no longer needed.
        //theMachine = FindObjectOfType<TheMachine>();
        mLook = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook;
        rotators = Resources.FindObjectsOfTypeAll<GunRotation>();
        TurnRotatorsOff();
    }

    void TurnRotatorsOn()
    {
        for (int i = 0; i < rotators.Length; i++)
        {
            rotators[i].enabled = true;
        }
    }

    void TurnRotatorsOff()
    {
        for (int i = 0; i < rotators.Length; i++)
        {
            rotators[i].enabled = false;
        }
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        TheMachine.stateMachine.ChangeState(new Walking());
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(true);
        scoreCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenCrafting()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(true);
        gunStatCanvas.SetActive(true);
        ammoCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
        TurnRotatorsOn();
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseCrafting()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(true);
        scoreCanvas.SetActive(true);
        TurnRotatorsOff();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenOption()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(true);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(false);
        scoreCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseOption()
    {
        mainMenu.SetActive(true);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(false);
        scoreCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenPause()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(true);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(false);
        scoreCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
    }

    public void ClosePause()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(true);
        scoreCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
    }

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
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(true);
        scoreCanvas.SetActive(true);

        pauseMenuUI.SetActive(false);
        TheMachine.fpc.enabled = true;
        TheMachine.cc.enabled = true;
        TheMachine.weapon.enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        if (!TheMachine.atWorkBench)
        {
            mainMenu.SetActive(false);
            crafting.SetActive(false);
            option.SetActive(false);
            pause.SetActive(true);
            gunStatCanvas.SetActive(false);
            ammoCanvas.SetActive(false);
            scoreCanvas.SetActive(false);

            pauseMenuUI.SetActive(true);
            TheMachine.fpc.enabled = false;
            TheMachine.cc.enabled = false;
            TheMachine.weapon.enabled = false;
            Cursor.visible = true;
            mLook.SetCursorLock(false);

            Time.timeScale = 0f;
            GameIsPaused = true;
        }
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

    public void Disable()
    {
        optionMenuUI.SetActive(false);
        OptionIsEnabled = false;
    }
    public void Enable()
    {
        optionMenuUI.SetActive(true);
        OptionIsEnabled = true;
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
