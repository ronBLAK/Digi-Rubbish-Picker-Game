using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (objectGrabbable == null)
            {
                // not carrying an object.. trying to grap the object
                float pickupDistance = 2f;
            
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }
                }   
            } else
            {
                // carrying.. Drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
