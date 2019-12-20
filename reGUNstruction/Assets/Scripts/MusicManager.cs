using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public bool LvOne;
    public bool LvTwo;
    public bool LvThree;
    public bool LvFour;
    public bool LvFive;
    public static bool PlayThisSong = true;
    AudioSource audioSource;
    public List<AudioClip> Lv1;
    public List<AudioClip> Lv2;
    public List<AudioClip> Lv3;
    public List<AudioClip> Lv4;
    public List<AudioClip> Lv5;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(string clipToPlay)
    {
        if (LvOne == true)
        {

            foreach (AudioClip clip in Lv1)
            {
                if (clip.name == clipToPlay)
                {
                    audioSource.PlayOneShot(clip);
                    //audioSource.volume = clipVolume;
                }
            }
        }
        if (LvTwo == true)
        {

            foreach (AudioClip clip in Lv2)
            {
                if (clip.name == clipToPlay)
                {
                    audioSource.PlayOneShot(clip);
                    //audioSource.volume = clipVolume;
                }
            }
        }
        if (LvThree == true)
        {

            foreach (AudioClip clip in Lv3)
            {
                if (clip.name == clipToPlay)
                {
                    audioSource.PlayOneShot(clip);
                    //audioSource.volume = clipVolume;
                }
            }
        }
    }
}

