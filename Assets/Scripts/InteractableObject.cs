using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactionIcon;
    public string sceneToLoad; // Set this in the Inspector

    private bool isPlayerNearby = false;

    void Start()
    {
        interactionIcon.SetActive(false); // Hide icon at start
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) // Change this for mobile buttons later
        {
            LoadNewScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionIcon.SetActive(false);
        }
    }

    public void LoadNewScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
