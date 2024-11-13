using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThermalKey : MonoBehaviour, IObservable
{
    List<IObserver> _observers = new();

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in _observers)
        {
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (var item in _observers)
        {
            
        }
    }
    public void Interact()
    {
        foreach (var item in _observers)
        {
            
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