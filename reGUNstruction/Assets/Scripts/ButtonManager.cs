using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    TheMachine theMachine;



    private void Start()
    {
        //Made public static reference to use state machine access instead, assigning a reference is no longer needed.
        //theMachine = FindObjectOfType<TheMachine>();
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

    private void Update()
    {
        
    }
}
