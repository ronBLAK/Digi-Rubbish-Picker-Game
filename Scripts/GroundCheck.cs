using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float slopeRayLength = 1.5f; // Length of the ray used to check for slopes
    public float groundCheckDistance = 0.1f; // Distance to check below the player for ground
    private CharacterController characterController; // Reference to the CharacterController component
    private bool isGrounded; // Flag indicating if the character is grounded

    private void Start()
    {
        // Get the CharacterController component attached to the player
        characterController = GetComponent<CharacterController>();
    }

    // Method to check if the character is on the ground or on a slope
    public void CheckGround()
    {
        // Perform a raycast directly downwards from the character's position to detect the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeRayLength))
        {
            // Calculate the angle of the slope by comparing the normal of the hit surface to the upward direction
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            // Check if the slope angle is within the walkable range (here between 0 and 45 degrees)
            if (slopeAngle > 0f && slopeAngle < 45f)
            {
                isGrounded = true; // The character is grounded if on a walkable slope
            }
            else
            {
                isGrounded = false; // The character is not grounded if the slope is too steep
            }
        }
        else
        {
            isGrounded = false; // The raycast did not hit anything, so the character is not grounded
        }

        // Additional check for ground objects directly below the character
        if (!isGrounded)
        {
            // Perform another raycast to check for any ground object within a closer distance
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
            {
                // If the collider hit by the raycast is tagged as "Ground", consider the character grounded
                if (hit.collider.CompareTag("Ground"))
                {
                    isGrounded = true;
                }
                else
                {
                    // If not grounded, move the character slightly downwards to simulate gravity
                    characterController.Move(Vector3.down * Time.deltaTime);
                }
            }
            else
            {
                // If no ground is detected, move the character slightly downwards to simulate gravity
                characterController.Move(Vector3.down * Time.deltaTime);
            }
        }
    }

    // Method to return the grounded state of the character
    public bool IsGrounded()
    {
        return isGrounded;
    }
}
