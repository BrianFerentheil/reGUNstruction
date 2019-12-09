using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{

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
