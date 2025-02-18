using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("References")]
    public AudioSource audioSource;
    public AudioClip janitorMusic;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = GetComponent<AudioManager>();
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void PlayJanitorMusic()
    {

    }
}
