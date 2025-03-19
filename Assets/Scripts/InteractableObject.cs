using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactionIcon;  // The floating interaction icon
    public Button enterButton; // The UI button to enter a new area
    public string sceneToLoad; // Scene to load when interacting

    private bool isPlayerNearby = false;

    void Start()
    {
        interactionIcon.SetActive(false);
        enterButton.gameObject.SetActive(false);

        // Assign button function
        enterButton.onClick.AddListener(LoadNewScene);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionIcon.SetActive(true);
            enterButton.gameObject.SetActive(true); // Show the button
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionIcon.SetActive(false);
            enterButton.gameObject.SetActive(false); // Hide the button
        }
    }

    void LoadNewScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
