using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    public Transform exitPoint; // Assign outside spawn point

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = exitPoint.position;
        }
    }
}
