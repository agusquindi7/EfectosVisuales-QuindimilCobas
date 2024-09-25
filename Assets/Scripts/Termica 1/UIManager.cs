using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour , IObserver
{
    public GameObject text;
    IObservable _obs;

    private void Start()
    {
        _obs = GetComponentInParent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
    }

    public void Notify(bool isOnButton)
    {
        if (isOnButton) 
        {
            text.SetActive (true);
        }
        else
        {
            text.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}
