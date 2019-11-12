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
        inGameCanvas.SetActive(true);
        theMachine.stateMachine.ChangeState(new Walking());
        
    }

    public void OpenCrafting()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(true);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
    }

    public void CloseCrafting()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(true);
    }

    public void OpenOption()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(true);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
    }

    public void CloseOption()
    {
        mainMenu.SetActive(true);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
        inGameCanvas.SetActive(false);
    }
    
    public void OpenPause()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(true);
    }

    public void ClosePause()
    {
        mainMenu.SetActive(false);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
    }

    private void Update()
    {
        
    }
}
