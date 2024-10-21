using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.Universal;

public class DitherEffect : MonoBehaviour, IObserver
{
    IObservable _obs;
    [SerializeField, Range (.1f,1)] float renderScale;
    [SerializeField] UniversalRenderPipelineAsset urpAsset;
    [SerializeField] Material ditherMat;

    private void Start()
    {
        _obs = GetComponentInParent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);

        ditherMat.SetFloat("_isOn", 0f);
    }

    public void Notify(bool isOnButton)
    {
        if(isOnButton)
        {
            urpAsset.renderScale = renderScale;
            ditherMat.SetFloat("_isOn", 1f);
        }
        else
        {
            urpAsset.renderScale = 1;
            ditherMat.SetFloat("_isOn", 0f);
        }
    }
}
