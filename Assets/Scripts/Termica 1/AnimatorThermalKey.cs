using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorThermalKey : MonoBehaviour , IObserver
{
    IObservable _obs;
    Animator animator;

    public void Notify(bool isOnButton)
    {
        animator.SetTrigger("isOn");
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

        _obs = GetComponent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}
