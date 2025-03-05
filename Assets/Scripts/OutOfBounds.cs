using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            PlayerLife player = other.GetComponent<PlayerLife>();
            player.TakeDamage(100f);
        }
    }
}
