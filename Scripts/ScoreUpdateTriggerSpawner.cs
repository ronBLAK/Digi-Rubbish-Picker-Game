using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateTriggerSpawner : MonoBehaviour
{
    public TrashCanSpawner trashCanSpawner; // Reference to TrashCanSpawner
    public GameObject planePrefab; // The plane prefab to clone
    public float heightOffset = 1.0f; // Height offset from the ground
    public float xOffset = -0.098f; // X-axis offset
    public float zOffset = -0.16288f; // Z-axis offset

    private void Start()
    {
        if (trashCanSpawner != null)
        {
            trashCanSpawner.OnTrashCanSpawned += ClonePlaneAtLocation; // Subscribe to the event
        }
        else
        {
            Debug.LogError("TrashCanSpawner reference is not set.");
        }
    }

    private void OnDestroy()
    {
        if (trashCanSpawner != null)
        {
            trashCanSpawner.OnTrashCanSpawned -= ClonePlaneAtLocation; // Unsubscribe from the event
        }
    }

    public void ClonePlaneAtLocation(GameObject spawnedTrashCan)
    {
        if (spawnedTrashCan != null && planePrefab != null)
        {
            // Adjust the position with the height offset, x offset, and z offset
            Vector3 adjustedPosition = spawnedTrashCan.transform.position;
            adjustedPosition.y += heightOffset;
            adjustedPosition.x += xOffset;
            adjustedPosition.z += zOffset;

            // Instantiate the planePrefab at the adjusted position
            GameObject clonedPlane = Instantiate(planePrefab, adjustedPosition, spawnedTrashCan.transform.rotation);

            // Set the parent of the cloned plane to the spawned trash can
            clonedPlane.transform.SetParent(spawnedTrashCan.transform);

            // Ensure the ScoreUpdate script is set up properly
            DestroyAndSpawnNewTrashAndTrashCan scoreUpdate = clonedPlane.GetComponent<DestroyAndSpawnNewTrashAndTrashCan>();
            if (scoreUpdate != null)
            {
                // Set up any necessary references or initializations for the ScoreUpdate script here
                scoreUpdate.SetSpawnerReferences(scoreUpdate.trashCanSpawnerGameObject, scoreUpdate.rubbishSpawnerGameObject, scoreUpdate.scoreUpdateTriggerSpawnerGameObject, scoreUpdate.trashCanPrefab);
            }
            else
            {
                Debug.LogWarning("ScoreUpdate script not found on the cloned plane.");
            }

            Debug.Log("Cloned Plane at Location: " + adjustedPosition);
        }
        else
        {
            Debug.LogWarning("Spawned Trash Can or Plane Prefab is not set.");
        }
    }
}
