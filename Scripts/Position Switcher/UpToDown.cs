using UnityEngine;
using System.Collections;

public class UpToDown : MonoBehaviour
{
    public Transform targetPositionMarker; // Reference to the Transform where the player should be placed
    public GameObject playerObj; // Reference to the player GameObject
    private PlayerMovement playerMovementScript; // Reference to the PlayerMovement script

    private void Start()
    {
        if (playerObj != null)
        {
            playerMovementScript = playerObj.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject == playerObj)
        {
            // Set the player's position to the target position marker's position
            if (targetPositionMarker != null)
            {
                StartCoroutine(MovePlayerToTarget());
            }
            else
            {
                Debug.LogWarning("Target position marker is not set.");
            }
        }
    }

    private IEnumerator MovePlayerToTarget()
    {
        // Disable PlayerMovement script to avoid conflicts
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        // Move player to the target position
        if (targetPositionMarker != null && playerObj != null)
        {
            CharacterController characterController = playerObj.GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Temporarily disable CharacterController
                characterController.enabled = false;

                // Move the player to the target position
                playerObj.transform.position = targetPositionMarker.position;

                // Re-enable CharacterController
                characterController.enabled = true;
            }
        }

        // Wait for a frame to ensure the position is set
        yield return null;

        // Re-enable PlayerMovement script
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }
    }
}
