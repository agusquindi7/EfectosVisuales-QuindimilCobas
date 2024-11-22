using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : Entities
{ 
    private CheckpointManager _checkpointManager;

    private void Start()
    {
        _checkpointManager = FindObjectOfType<CheckpointManager>();
    }

    public override void LifeRemaining()
    {
        if (life <= 0)
        {
            if (_checkpointManager != null)
            {
                Respawn();
            }
            else
            {
                Debug.Log("El Player No tiene Vida");
                //Destroy(gameObject);
            }
        }
    }

    private void Respawn()
    {
        _checkpointManager.LoadCheckpoint(transform);
        life = maxLife;
        Debug.Log("Respawn realizado y vida restaurada.");
    }
}
