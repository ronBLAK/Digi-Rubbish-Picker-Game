using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanSpawner : MonoBehaviour
{
    public GameObject trashcanPrefab; // The prefab for the trash can to spawn
    public TrashCanLocationSpawner trashCanLocSpawn; // Reference to the TrashCanLocationSpawner for getting spawn locations
    public GameObject spawnedTrashCan; // Reference to the currently spawned trash can

    // Event to notify other scripts when a trash can has been spawned
    public event Action<GameObject> OnTrashCanSpawned;

    public void Update()
    {
        // Check if there is no currently spawned trash can
        if (spawnedTrashCan == null)
        {
            // Get a new spawn location from TrashCanLocationSpawner
            Transform spawnLocation = trashCanLocSpawn.GetSelectedTrashCanLocation();
            if (spawnLocation != null)
            {
                // Spawn the trash can at the selected location
                SpawnTrashCanOnMap(trashcanPrefab, spawnLocation);
            }
        }
    }

    // Method to instantiate a trash can at the specified location
    public GameObject SpawnTrashCanOnMap(GameObject trashCanPrefab, Transform trashCanPos)
    {
        // Instantiate the trash can prefab at the given position
        spawnedTrashCan = Instantiate(trashCanPrefab, trashCanPos.position, Quaternion.identity);

        // Notify any listeners that a trash can has been spawned
        OnTrashCanSpawned?.Invoke(spawnedTrashCan);

        return spawnedTrashCan;
    }
}
