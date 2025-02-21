using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("References")]
    public AudioSource audioSource;
    public AudioClip janitorMusic, labMusic, doorSound;
    public float janitorVolume, labVolume, doorVolume;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = GetComponent<AudioManager>();
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void AlertedScientists(AudioClip audioClip, float volume)
    {
        audioSource.PlayOneShot(audioClip, volume);
    }

    public void PlayDoorSound()
    {
        audioSource.PlayOneShot(doorSound, doorVolume);
    }
}
