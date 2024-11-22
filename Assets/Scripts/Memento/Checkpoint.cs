using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static List<Checkpoint> Checkpoints = new List<Checkpoint>();
    private Renderer _renderer;

    private void Awake()
    {
        Checkpoints.Add(this);
        _renderer = GetComponent<Renderer>();
        SetColor(Color.red);
    }

    private void OnDestroy()
    {
        Checkpoints.Remove(this);
    }

    public void SetColor(Color color)
    {
        if (_renderer != null)
        {
            _renderer.material.color = color;
        }
    }
}
