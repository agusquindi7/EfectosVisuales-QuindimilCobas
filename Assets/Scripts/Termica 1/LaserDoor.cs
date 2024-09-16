using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour, IObserver
{
    IObservable _obs;
    public bool isPressingButton = false;
    [SerializeField] GameObject laserRays;
    public void Start()
    {
        //laserRays = GetComponentInChildren<GameObject>();

        _obs = GetComponentInParent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E)) isPressingButton = !isPressingButton;
    }

    public void Notify(bool isOnButton)
    {
        if (isOnButton)
        {
            laserRays.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}
