using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody; // The player's body object
    public Transform thirdPersonCamera; // Third person camera
    public Transform firstPersonCamera; // First person camera
    public float sensitivity = 100f; // Mouse sensitivity
    public float clampAngle = 80f; // Maximum angle to look up and down

    private float verticalRotation = 0f;
    private bool isFirstPerson = false; // Flag to track camera mode

    [SerializeField] private GameObject crosshair;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set initial camera mode
        SetCamera(isFirstPerson);
    }

    void Update()
    {
        // Check for input to toggle camera mode
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFirstPerson = !isFirstPerson;
            SetCamera(isFirstPerson);
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the player's body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    // Method to set camera position based on camera mode
    private void SetCamera(bool isFirstPerson)
    {
        if (isFirstPerson)
        {
            // Enable first person camera, disable third person camera
            thirdPersonCamera.gameObject.SetActive(false);
            firstPersonCamera.gameObject.SetActive(true);
            crosshair.SetActive(true);
            
        }
        else
        {
            // Enable third person camera, disable first person camera
            thirdPersonCamera.gameObject.SetActive(true);
            firstPersonCamera.gameObject.SetActive(false);
            crosshair.SetActive(false);
        }
    }
}
