using UnityEngine;
using UnityEngine.SceneManagement;

public class PaperScaleButton : MonoBehaviour
{
    public float scaleMultiplier = 1.2f;
    public Transform text;
    public AudioSource audioSource;
    public AudioClip clipHover, clipClick;
    private Vector3 originalScale, originalTextScale;
    public string levelName;

    private void Awake()
    {
        originalScale = transform.localScale;
        originalTextScale = text.localScale;
    }

    private void OnMouseEnter()
    {
        audioSource.PlayOneShot(clipHover);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast golpeó: " + hit.collider.gameObject.name); // Ver qué objeto detecta
                if (hit.collider.gameObject == gameObject) // Si el raycast pega en este objeto
                {
                    audioSource.PlayOneShot(clipClick);
                    if (hit.collider.gameObject.name == "PaperExit")
                    {
                        Debug.Log("Saliendo del juego!");
                        Application.Quit();
                    }
                    else 
                    { 
                    SceneManager.LoadSceneAsync(levelName);
                    }
                }
            }
        }

        // Detección de hover manual
        Ray hoverRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hoverHit;

        if (Physics.Raycast(hoverRay, out hoverHit))
        {
            if (hoverHit.collider.gameObject == gameObject)
            {
                Debug.Log("Raycast se poso sobre: " + hoverHit.collider.gameObject.name);
                transform.localScale = originalScale * scaleMultiplier;
                text.localScale = originalTextScale * scaleMultiplier;
            }
            else
            {
                transform.localScale = originalScale;
                text.localScale = originalTextScale;
            }
        }
        else
        {
            transform.localScale = originalScale;
            text.localScale = originalTextScale;
        }
    }
}
