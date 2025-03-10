using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("References")]
    public IsGrounded isGrounded;
    public AudioSource audioSourceSFX, audioSourceMusic, audioSourceBabitas;
    public AudioClip janitorMusic, labMusic, doorSound, backgroundMusic, warningMusic, unnervingMusic, hurtSound;
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
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Debug.Log("Now playin Experimentation Room clip");
            audioSourceMusic.clip = backgroundMusic;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("Now playin nff0nef0SN026S4['. clip");
            audioSourceMusic.volume = 1f;
            audioSourceMusic.clip = unnervingMusic;
        }
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

    public void PlayHurtSoundOneShot()
    {
        StartCoroutine(HurtSoundWithCooldown());
    }

    public IEnumerator HurtSoundWithCooldown()
    {
        audioSourceSFX.PlayOneShot(hurtSound, 1f);
        yield return new WaitForSeconds(.5f);
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
