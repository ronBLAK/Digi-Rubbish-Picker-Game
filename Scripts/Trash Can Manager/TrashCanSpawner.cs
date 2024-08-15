using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanSpawner : MonoBehaviour
{
    public GameObject trashcanPrefab;
    public TrashCanLocationSpawner trashCanLocSpawn;
    public GameObject spawnedTrashCan;

    // Event to notify when a trash can is spawned
    public event Action<GameObject> OnTrashCanSpawned;

    public void Update()
    {
        if (spawnedTrashCan == null)
        {
            Transform spawnLocation = trashCanLocSpawn.GetSelectedTrashCanLocation();
            if (spawnLocation != null)
            {
                SpawnTrashCanOnMap(trashcanPrefab, spawnLocation);
            }
        }
    }

    public GameObject SpawnTrashCanOnMap(GameObject trashCanPrefab, Transform trashCanPos)
    {
        spawnedTrashCan = Instantiate(trashCanPrefab, trashCanPos.position, Quaternion.identity);
        OnTrashCanSpawned?.Invoke(spawnedTrashCan); // Notify listeners that a trash can has been spawned
        return spawnedTrashCan;
    }
}
