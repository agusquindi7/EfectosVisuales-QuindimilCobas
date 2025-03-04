using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieFromLaser : MonoBehaviour
{
    [SerializeField] GameObject panel;
    Entities playerLife;


    private void Awake()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLife>())
        {
            playerLife = other.GetComponent<PlayerLife>();
            //panel.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //Time.timeScale = 0f;
            playerLife.TakeDamage(25);
            if (playerLife.LifeRemainingPJ())
            {
                Animator playerAnimator = playerLife.GetComponent<Animator>();
                playerAnimator.SetTrigger("isDeath");
            }
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