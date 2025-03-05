using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPanelFunction : MonoBehaviour
{
    public GameObject panel;

    public void Restart()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
