using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the Player in the Inspector
    public float smoothSpeed = 5f; // Adjust for smoother movement
    public Vector3 offset = new Vector3(0, 2, -10); // Adjust if needed

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
