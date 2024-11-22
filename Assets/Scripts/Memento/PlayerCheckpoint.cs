using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private CheckpointManager _checkpointManager;

    private void Start()
    {
        _checkpointManager = FindObjectOfType<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var checkpoint = other.GetComponent<Checkpoint>();
        if (checkpoint != null)
        {
            _checkpointManager.SaveCheckpoint(transform, checkpoint);
            Debug.Log("Checkpoint guardado.");
        }
    }

    public void Respawn()
    {
        _checkpointManager.LoadCheckpoint(transform);
        Debug.Log("Respawn realizado.");
    }
}
