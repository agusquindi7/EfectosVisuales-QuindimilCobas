using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class VictoryConditionTEMP : MonoBehaviour
{
    public string levelName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            SceneManager.LoadScene(levelName);
        }
    }
}