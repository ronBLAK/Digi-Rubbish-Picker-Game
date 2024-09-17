using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // Namespace for Visual Scripting (if used in the project)
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody; // Reference to the object's Rigidbody component
    private Transform objectGrabPointTransform; // Transform where the object should be moved when grabbed

    private void Awake()
    {
        // Get and store the Rigidbody component attached to this object
        objectRigidbody = GetComponent<Rigidbody>();
    }

    // Method to be called when grabbing the object
    public void Grab(Transform objectGrabPointTransform)
    {
        // Set the target position to the specified grab point
        this.objectGrabPointTransform = objectGrabPointTransform;
        // Disable gravity while the object is being held
        objectRigidbody.useGravity = false;
    }

    // Method to be called when dropping the object
    public void Drop()
    {
        // Clear the grab point as the object is being dropped
        this.objectGrabPointTransform = null;
        // Re-enable gravity to allow the object to fall
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        // Check if the object is being grabbed
        if (objectGrabPointTransform != null)
        {
            // Smoothly move the object towards the grab point using Lerp
            float lerpSpeed = 10f; // Speed of the movement
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            // Move the object's position smoothly
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
