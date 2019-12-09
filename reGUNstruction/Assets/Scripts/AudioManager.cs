using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.Play();
    }

    
    void Update()
    {
        
    }

    public void PlayAudio(string clipToPlay)
    {
        foreach(AudioClip clip in clips)
        {
            if(clip.name == clipToPlay)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
