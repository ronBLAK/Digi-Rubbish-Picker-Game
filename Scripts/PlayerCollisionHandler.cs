using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private CharacterController characterController; // Reference to the CharacterController component

    void Start()
    {
        // Get and store the CharacterController component attached to this object
        characterController = GetComponent<CharacterController>();
    }

    // Called when the CharacterController collides with another collider
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collided object is not the player itself
        if (!hit.gameObject.CompareTag("Player"))
        {
            // Log the name of the collided object for debugging purposes
            Debug.Log("Collided with: " + hit.gameObject.name);

            // Example action: Stop the player's movement by setting movement vector to zero
            // Note: This will not stop all movement if other forces or inputs are applied
            characterController.SimpleMove(Vector3.zero);
        }
    }
}
