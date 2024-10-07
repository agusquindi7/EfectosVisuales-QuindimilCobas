using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager Instance { get; private set; }

    [SerializeField] float _width;
    [SerializeField] float _height;

    public List<Boid> AllBoids { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        AllBoids = new List<Boid>();
    }

    //Ojo que puede agregar repetidos
    public void AddBoid(Boid b) => AllBoids.Add(b);

    public Vector3 GetPositionInBounds(Vector3 position)
    {
        float halfWidth = _width / 2;
        float halfHeight = _height / 2;

        if (position.x > halfWidth) position.x = -halfWidth;
        else if (position.x < -halfWidth) position.x = halfWidth;
        if (position.z > halfHeight) position.z = -halfHeight;
        else if (position.z < -halfHeight) position.z = halfHeight;

        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Vector2.zero, new Vector3(_width, 0, _height));
    }
}
