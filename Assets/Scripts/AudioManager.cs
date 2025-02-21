using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("References")]
    public AudioSource audioSourceSFX, audioSourceMusic;
    public AudioClip janitorMusic, labMusic, doorSound, backgroundMusic, warningMusic;
    public float janitorVolume, labVolume, doorVolume;

    public bool isPlayingWarning = false;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = GetComponent<AudioManager>();
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        isPlayingWarning = false;

        audioSourceMusic.clip = backgroundMusic;
    }

    public void AlertedScientists(AudioClip audioClip, float volume)
    {
        audioSourceSFX.PlayOneShot(audioClip, volume);
    }

    public void PlayDoorSound()
    {
        audioSourceSFX.PlayOneShot(doorSound, doorVolume);
    }

    public void PlayWarningMusic()
    {
        if (!isPlayingWarning) 
        {
            audioSourceMusic.clip = warningMusic;
            audioSourceMusic.Play();
            isPlayingWarning = true;
        }
    }
}
