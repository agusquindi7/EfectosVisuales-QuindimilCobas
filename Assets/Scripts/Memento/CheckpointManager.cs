using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Stack<CheckpointMemento> _checkpoints = new Stack<CheckpointMemento>();
    private Checkpoint _activeCheckpoint;

    public void SaveCheckpoint(Transform playerTransform, Checkpoint checkpoint)
    {
        if (_activeCheckpoint != null)
        {
            _activeCheckpoint.SetColor(Color.red);
        }

        _activeCheckpoint = checkpoint;
        _activeCheckpoint.SetColor(Color.green);

        _checkpoints.Push(new CheckpointMemento(playerTransform.position, playerTransform.rotation));
    }

    public void LoadCheckpoint(Transform playerTransform)
    {
        if (_checkpoints.Count == 0)
        {
            Debug.LogWarning("No hay checkpoints guardados.");
            return;
        }

        var memento = _checkpoints.Pop();
        playerTransform.position = memento.Position;
        playerTransform.rotation = memento.Rotation;
    }

    public class CheckpointMemento
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public CheckpointMemento(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}
