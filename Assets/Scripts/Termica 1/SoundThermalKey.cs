using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundThermalKey : MonoBehaviour, IObserver
{
    public AudioClip sfx;
    [SerializeField] AudioSource aSource;
    IObservable _obs;

    private void Awake()
    {
        _obs = GetComponent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
    }

    public void Notify(bool isOnButton)
    {
        aSource.PlayOneShot(sfx,1f);
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}