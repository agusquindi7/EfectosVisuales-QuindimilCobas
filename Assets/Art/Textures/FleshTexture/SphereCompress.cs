using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCompress : MonoBehaviour
{
    public float compressionAmount = 0.8f; // Scale factor for compression
    public float compressionSpeed = 5f;   // Speed of compression and release
    public float compressionRadius = 0.5f; // Radius around the collision normal for compression

    private Mesh originalMesh;          // Original mesh
    private Mesh deformedMesh;          // Deformed mesh
    private Vector3[] originalVertices; // Original vertex positions (local space)
    private Vector3[] modifiedVertices; // Modified vertex positions (local space)
    private Dictionary<Vector3, List<int>> sharedVertices; // Map of shared vertices
    private bool isCompressing = false;

    private void Start()
    {
        // Duplicate the original mesh to avoid modifying the shared asset
        originalMesh = GetComponent<MeshFilter>().mesh;
        deformedMesh = Instantiate(originalMesh);
        originalVertices = originalMesh.vertices;
        modifiedVertices = new Vector3[originalVertices.Length];
        GetComponent<MeshFilter>().mesh = deformedMesh;

        // Initialize modified vertices
        for (int i = 0; i < originalVertices.Length; i++)
        {
            modifiedVertices[i] = originalVertices[i];
        }

        // Build shared vertices map
        BuildSharedVertices();
    }

    private void OnCollisionStay(Collision collision)
    {
        isCompressing = true;

        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 collisionPoint = contact.point;
            Vector3 collisionNormal = contact.normal;

            // Modify vertices near the collision point
            ApplyCompression(collisionPoint, collisionNormal);
        }

        // Apply the modified vertices to the mesh
        deformedMesh.vertices = modifiedVertices;
        deformedMesh.RecalculateNormals();
    }

    private void OnCollisionExit(Collision collision)
    {
        isCompressing = false;
        StopAllCoroutines();
        StartCoroutine(Release());
    }

    private void ApplyCompression(Vector3 collisionPoint, Vector3 collisionNormal)
    {
        for (int i = 0; i < originalVertices.Length; i++)
        {
            // Transform vertex to world space
            Vector3 worldVertexPos = transform.TransformPoint(originalVertices[i]);

            // Calculate the distance from the vertex to the collision plane
            float distanceToPlane = Vector3.Dot(worldVertexPos - collisionPoint, collisionNormal);

            if (Mathf.Abs(distanceToPlane) < compressionRadius)
            {
                float compressionFactor = Mathf.Lerp(1f, compressionAmount, (compressionRadius - Mathf.Abs(distanceToPlane)) / compressionRadius);
                Vector3 newVertexPos = worldVertexPos - collisionNormal * (1f - compressionFactor) * Mathf.Sign(distanceToPlane);

                // Update all shared vertices to maintain mesh integrity
                foreach (int sharedIndex in sharedVertices[originalVertices[i]])
                {
                    modifiedVertices[sharedIndex] = transform.InverseTransformPoint(newVertexPos);
                }
            }
        }
    }

    private IEnumerator Release()
    {
        while (!isCompressing)
        {
            bool isFullyReset = true;

            for (int i = 0; i < originalVertices.Length; i++)
            {
                // Smoothly return vertices to their original positions
                modifiedVertices[i] = Vector3.Lerp(modifiedVertices[i], originalVertices[i], Time.deltaTime * compressionSpeed);

                if ((modifiedVertices[i] - originalVertices[i]).sqrMagnitude > 0.0001f)
                {
                    isFullyReset = false;
                }
            }

            deformedMesh.vertices = modifiedVertices;
            deformedMesh.RecalculateNormals();

            if (isFullyReset) break;

            yield return null;
        }

        deformedMesh.vertices = originalVertices;
        deformedMesh.RecalculateNormals();
    }

    private void BuildSharedVertices()
    {
        sharedVertices = new Dictionary<Vector3, List<int>>();

        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];

            if (!sharedVertices.ContainsKey(vertex))
            {
                sharedVertices[vertex] = new List<int>();
            }

            sharedVertices[vertex].Add(i);
        }
    }
}
