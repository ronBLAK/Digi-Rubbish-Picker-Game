using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f; // player walking speed
    public float runSpeed = 6f;
    private Animator mainCharAnimControl;
    public Camera playerCamera;
    private float currentSpeed;

    // Reference to the GroundDetector script
    private GroundCheck groundDetector;

    public CharacterController playerCharacterController;

    void Start()
    {
        mainCharAnimControl = GetComponent<Animator>();
        currentSpeed = walkSpeed;

        // Get the GroundDetector component attached to the same GameObject
        groundDetector = GetComponent<GroundCheck>();
    }

    void Update()
    {
        if (walkSpeed >= 6)
        {
            walkSpeed = 6;
        }
        if (runSpeed >= 7)
        {
            runSpeed = 7;
        }

        // Retrieve input for horizontal and vertical movement relative to camera
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get forward and right vectors based on camera orientation
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // Project forward and right vectors onto the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction relative to camera
        Vector3 movementDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // Check if the Shift key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            // Toggle between walk and run speed
            currentSpeed = (currentSpeed == walkSpeed) ? runSpeed : walkSpeed;

            // Trigger animation based on speed change
            if (currentSpeed == walkSpeed)
            {
                mainCharAnimControl.SetBool("IsRunning", false);
            }
            else
            {
                mainCharAnimControl.SetBool("IsRunning", true);
            }
        }

        

        // Check if the Shift key is released
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            // Set animation to walk immediately upon releasing Shift
            mainCharAnimControl.SetBool("IsRunning", false);
            mainCharAnimControl.SetBool("IsWalking", true);

            // Update current speed immediately upon releasing Shift
            currentSpeed = walkSpeed;
        }

        // Apply movement based on input and current speed
        Vector3 movement = movementDirection * currentSpeed * Time.deltaTime;
        playerCharacterController.Move(movement);

        // Smooth the movement to reduce snapping
        Vector3 targetPosition = transform.position + movement;
        playerCharacterController.Move(targetPosition - transform.position);

        // Set animation parameters for movement
        if (movement.magnitude > 0)
        {
            mainCharAnimControl.SetBool("IsWalking", true);
        }
        else
        {
            mainCharAnimControl.SetBool("IsWalking", false);
        }

        // Check for ground underneath the character using the GroundDetector script
        groundDetector.CheckGround();

        // Check if the player is grounded
        bool isGrounded = groundDetector.IsGrounded();

        // Example: You can add logic here to adjust player behavior based on being grounded or not
        if (!isGrounded)
        {
            // Example: Apply additional logic for airborne behavior
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Ensure the player stops only on obstacles with the "Obstacles" tag
        if (hit.collider.CompareTag("Obstacles"))
        {
            playerCharacterController.Move(Vector3.zero);
            Debug.Log("Player stopped due to collision with: " + hit.collider.gameObject.name);
        }
    }
}
