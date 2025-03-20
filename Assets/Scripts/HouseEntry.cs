using UnityEngine;
using UnityEngine.UI;

public class HouseEntry : MonoBehaviour
{
    public Transform insidePosition; // Assign the inside spawn point
    public Transform outsidePosition; // Assign the outside spawn point

    public GameObject interactionIcon; // Icon above the house
    public GameObject enterButton; // UI button to enter

    private bool playerIsNear = false;
    private Transform player;

    void Start()
    {
        interactionIcon.SetActive(false);
        enterButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerIsNear = true;
            interactionIcon.SetActive(true);
            enterButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            interactionIcon.SetActive(false);
            enterButton.SetActive(false);
        }
    }

    public void EnterHouse()
    {
        if (playerIsNear)
        {
            player.position = insidePosition.position;
            interactionIcon.SetActive(false);
            enterButton.SetActive(false);
        }
    }
}
