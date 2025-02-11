using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedButton : MonoBehaviour
{
    public GameObject defeatPanel;
    public void DefeatPanel()
    {
        Time.timeScale = 0f;
        defeatPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PanelRestart()
    {
        Time.timeScale = 1f;
        defeatPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
