using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    // Reference to the player's body object to rotate horizontally
    public Transform playerBody;
    // Reference to the third person camera
    public Transform thirdPersonCamera;
    // Reference to the first person camera
    public Transform firstPersonCamera;
    // Mouse sensitivity for camera movement
    public float sensitivity = 100f;
    // Maximum angle to look up and down
    public float clampAngle = 80f;

    private float verticalRotation = 0f; // Current vertical rotation angle
    private bool isFirstPerson = false; // Flag to track if the camera is in first-person mode

    [SerializeField] private GameObject crosshair; // Reference to the crosshair object

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set the initial camera mode
        SetCamera(isFirstPerson);
    }

    void Update()
    {
        // Toggle camera mode when the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFirstPerson = !isFirstPerson;
            SetCamera(isFirstPerson);
        }

        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the player's body horizontally based on mouse input
        playerBody.Rotate(Vector3.up * mouseX);

        // Update and clamp the vertical rotation of the camera
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        // Apply the vertical rotation to the camera's local rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    // Method to switch between first-person and third-person camera modes
    private void SetCamera(bool isFirstPerson)
    {
        if (isFirstPerson)
        {
            // Enable the first-person camera and disable the third-person camera
            thirdPersonCamera.gameObject.SetActive(false);
            firstPersonCamera.gameObject.SetActive(true);
            crosshair.SetActive(true); // Show the crosshair in first-person mode
        }
        else
        {
            // Enable the third-person camera and disable the first-person camera
            thirdPersonCamera.gameObject.SetActive(true);
            firstPersonCamera.gameObject.SetActive(false);
            crosshair.SetActive(false); // Hide the crosshair in third-person mode
        }
    }
}
