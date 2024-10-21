using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class UIManager : MonoBehaviour, IObserver
{
    public GameObject text;
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
            text.SetActive(true);
            tmp.text = "RETRO MODE ACTIVATED";
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
    //IEnumerator TextSeconds()
    //{
    //    text.SetActive(true);
    //    yield return new WaitForSeconds(2f);
    //    text.SetActive(false);
    //}
}