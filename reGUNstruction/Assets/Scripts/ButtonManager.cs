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
        theMachine = FindObjectOfType<TheMachine>();
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
        theMachine.stateMachine.ChangeState(new Walking());
        gunStatCanvas.SetActive(false);
        ammoCanvas.SetActive(true);
        scoreCanvas.SetActive(true);
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
