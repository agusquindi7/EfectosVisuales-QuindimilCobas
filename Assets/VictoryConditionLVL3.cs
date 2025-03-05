using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConditionLVL3 : MonoBehaviour
{
    public int nextLvlIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(nextLvlIndex);
        }
    }
}
