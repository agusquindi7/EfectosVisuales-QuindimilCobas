using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool <T> //la clase al ser generica devuelve algo
{
    Func<T> _Factory;
    Action<T> _TurnOn, _TurnOff;
    
    //List<T> _stockAvailable = new();
    List<T> _stockAvailable = new List<T>();

    //func es un metodo que siempre devuelve algo. ya sea, int, string o gameobject
    public ObjectPool(Func<T> Factory, Action <T> TurnOn, Action<T> TurnOff, int initialStock = 5)
    {
        _Factory = Factory;
        _TurnOn = TurnOn;
        _TurnOff = TurnOff;

        for (int i = 0; i < initialStock; i++) //crea las balas, las desactiva y las guarda en la lista
        {
            var x = _Factory();
            _TurnOff(x);

            _stockAvailable.Add(x);
        }
    }

    public T Get() //che me das una bala?
    {
        if (_stockAvailable.Count > 0)
        {
            var x = _stockAvailable[0];
            _stockAvailable.Remove(x); //lo saco de la lista

            _TurnOn(x);
            return x;
        }
        return _Factory(); //si no tengo balas disponibles
    }

    public void Return(T value) //se la preste a rifle y ahora me la devuelve
    {
        _TurnOff(value);
        _stockAvailable.Add(value);
    }
}
