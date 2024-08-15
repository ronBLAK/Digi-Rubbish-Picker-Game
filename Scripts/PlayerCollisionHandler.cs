using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if collided with an obstacle
        if (!hit.gameObject.CompareTag("Player")) // Ensure it's not colliding with itself
        {
            Debug.Log("Collided with: " + hit.gameObject.name);

            // Example: Stop the player's movement
            characterController.SimpleMove(Vector3.zero);
        }
    }
}
