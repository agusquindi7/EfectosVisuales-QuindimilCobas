using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class UIManager : MonoBehaviour, IObserver
{
    public GameObject text;
    //public string generalText = "Device Activated";
    public TextMeshProUGUI tmp; 
    IObservable _obs;
    private void Start()
    {
        _obs = GetComponentInParent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
        Debug.Log(_obs);

        text.SetActive(false);
    }
    public void Notify(bool isOnButton)
    {
        if (isOnButton)
        {
            StartCoroutine(TextSeconds("Device Activated"));
        }
        else
        {
            StartCoroutine(TextSeconds("Device Deactivated"));
        }
    }
    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }

    IEnumerator TextSeconds(string textString)
    {
        text.SetActive(true);
        tmp.text = textString;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}