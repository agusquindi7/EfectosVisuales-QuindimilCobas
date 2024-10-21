using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Computer : MonoBehaviour , IObservable , IInteractuable
{
    List<IObserver> _observers = new();
    [SerializeField] KeyCode myKey;
    bool isKeyOn = false;
    [SerializeField] float radius;

    public GameObject text;
    public TextMeshProUGUI tmp;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hit in colliders)
        {
            if(hit.GetComponent<PlayerLife>())
            {
                if (!isKeyOn)
                {
                    text.SetActive(true);
                    tmp.text = "Press 'E'' to activate RETRO MODE";
                }
                Interact();
            }
            else 
            {
                text.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.green;
    }

    public void Interact()
    {
        if(Input.GetKeyDown(myKey))
        {
            isKeyOn = !isKeyOn;

            foreach (var item in _observers)
            {
                item.Notify(isKeyOn);
            }
        }
    }

    public void Subscribe(IObserver obs)
    {
        if (!_observers.Contains(obs))
            _observers.Add(obs);
    }
    public void Unsubscribe(IObserver obs)
    {
        if (_observers.Contains(obs))
            _observers.Remove(obs);
    }

}
