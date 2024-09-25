using UnityEngine;

public class ObjDestroyFinished : MonoBehaviour, IObserver
{
    IObservable _obs;

    private void Awake()
    {
        _obs = GetComponentInParent<IObservable>();
        if (_obs != null)
            _obs.Subscribe(this);
    }

    public void Notify(bool isOnButton)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _obs.Unsubscribe(this);
    }
}
