using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject crafting;
    public GameObject option;
    public GameObject pause;

    public void StartGame()
    {
        mainMenu.SetActive(false);
    }

    public void OpenCrafting()
    {
        crafting.SetActive(true);
    }

    public void CloseCrafting()
    {
        crafting.SetActive(false);
    }

    public void OpenOption()
    {
        option.SetActive(true);
    }

    public void CloseOption()
    {
        option.SetActive(false);
    }
    
    public void OpenPause()
    {
        pause.SetActive(true);
    }

    public void ClosePause()
    {
        pause.SetActive(false);
    }

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        crafting.SetActive(false);
        option.SetActive(false);
        pause.SetActive(false);
    }
}
