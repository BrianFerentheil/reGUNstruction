using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuUI : MonoBehaviour
{
    public static bool OptionIsEnabled = false;
    public GameObject optionMenuUI;

// Update is called once per frame

    public void Enable()
    {
        optionMenuUI.SetActive(false);
        OptionIsEnabled = false;
    }
    public void Disable()
    {
        optionMenuUI.SetActive(true);
        OptionIsEnabled = true;
    }
}

