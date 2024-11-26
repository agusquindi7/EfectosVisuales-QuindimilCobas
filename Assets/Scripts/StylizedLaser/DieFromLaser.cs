using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieFromLaser : MonoBehaviour
{
    [SerializeField] GameObject panel;


    private void Awake()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}