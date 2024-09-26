using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalKey : MonoBehaviour , IObservable, IInteractuable
{
    List<IObserver> _observers = new();

    //private void OnTriggerEnter(Collider other)
    //{
    //    foreach (var item in _observers)
    //    {
    //        item.Notify(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    foreach (var item in _observers)
    //    {
    //        item.Notify(false);
    //    }
    //}
    public void Interact()
    {
        foreach (var item in _observers)
        {
            item.Notify(true);
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
