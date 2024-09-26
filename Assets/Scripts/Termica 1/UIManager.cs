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
        StartCoroutine(TextSeconds());
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }

    IEnumerator TextSeconds()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
