using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPause : MonoBehaviour
{
    public static ManagerPause instance;
    public event Action TotalUpdates = delegate { };
    public Action ArtificialUpdate;

    void Awake()
    {
        instance = this;      
    }

    public void Subscribe(Action callback)
    {
        TotalUpdates += callback;
    }
    public void Unsubscribe(Action callback)
    {
        TotalUpdates -= callback;
    }

    public void Pause(bool active)
    {
        if (active)
            ArtificialUpdate = delegate { };
        else
            ArtificialUpdate = TotalUpdates;
    }

    void Update()
    {
        ArtificialUpdate();
    }
}
