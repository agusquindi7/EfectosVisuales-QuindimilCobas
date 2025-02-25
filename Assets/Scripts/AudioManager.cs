using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("References")]
    public IsGrounded isGrounded;
    public AudioSource audioSourceSFX, audioSourceMusic, audioSourceBabitas;
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

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && isGrounded.isGrounded) 
        {
            audioSourceBabitas.mute = false;
        }
        else if (Input.GetAxisRaw("Vertical") != 0 && isGrounded.isGrounded)
        {
            audioSourceBabitas.mute = false;
        }
        else audioSourceBabitas.mute = true;
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
