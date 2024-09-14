using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour , IObserver
{
    public TextMeshProUGUI text;
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
            text.text = "Themal Key fully fixed";
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}
