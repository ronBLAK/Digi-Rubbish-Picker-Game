using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float slopeRayLength = 1.5f;
    public float groundCheckDistance = 0.1f; // Distance to check below the player for ground
    private CharacterController characterController;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void CheckGround()
    {
        // Check for ground underneath the character using a raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeRayLength))
        {
            // Calculate the angle of the slope
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            // Check if the slope angle is within walkable range (adjust as needed)
            if (slopeAngle > 0f && slopeAngle < 45f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }

        // Additional check for ground object
        if (!isGrounded)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    isGrounded = true;
                }
                else
                {
                    characterController.Move(Vector3.down * Time.deltaTime);
                }
            }
            else
            {
                characterController.Move(Vector3.down * Time.deltaTime);
            }
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
