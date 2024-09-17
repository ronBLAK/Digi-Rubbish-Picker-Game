using UnityEngine;
using System.Collections;

public class DownToUp : MonoBehaviour
{
    public Transform targetPositionMarker; // Reference to the Transform where the player should be placed
    public GameObject playerObj; // Reference to the player GameObject
    private PlayerMovement playerMovementScript; // Reference to the PlayerMovement script

    private void Start()
    {
        // Get the PlayerMovement script from the player object if it is assigned
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
            // If the target position marker is set, start moving the player
            if (targetPositionMarker != null)
            {
                StartCoroutine(MovePlayerToTarget());
            }
            else
            {
                Debug.LogWarning("Target position marker is not set."); // Log warning if marker is not set
            }
        }
    }

    private IEnumerator MovePlayerToTarget()
    {
        // Disable PlayerMovement script to avoid conflicts during movement
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        // Move player to the target position if both are set
        if (targetPositionMarker != null && playerObj != null)
        {
            CharacterController characterController = playerObj.GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Temporarily disable CharacterController to directly set the position
                characterController.enabled = false;

                // Move the player to the target position
                playerObj.transform.position = targetPositionMarker.position;
                // Re-enable CharacterController after setting the position
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
