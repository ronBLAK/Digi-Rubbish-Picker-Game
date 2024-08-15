using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DestroyAndSpawnNewTrashAndTrashCan : MonoBehaviour
{
    private ScoreIncrement scoreIncrement;
    private CountdownTimer countdownTimer;
    private PlayerMovement playerMovement;

    public GameObject scoreIncrementGameObject;
    public GameObject countdownTimerGO;
    public GameObject playerMovementGO;

    // Trash can prefab reference
    public GameObject trashCanPrefab;

    // Reference to GameObjects containing relevant scripts to manage rubbish and trash spawn
    public GameObject trashCanSpawnerGameObject;
    public GameObject rubbishSpawnerGameObject;
    public GameObject scoreUpdateTriggerSpawnerGameObject;

    // Reference to scripts that manage rubbish and trash can spawn
    private TrashCanLocationSpawner trashCanLocationSpawner;
    private TrashCanSpawner trashCanSpawner;
    private RubbishLocationSpawner rubbishLocationSpawner;
    private RubbishSpawner rubbishSpawner;
    private ScoreUpdateTriggerSpawner scoreUpdateTriggerSpawner;

    private bool isHandlingCollision = false;

    private void Start()
    {
        // Setting all the script variables to respective script files in project
        trashCanLocationSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanLocationSpawner>();
        trashCanSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanSpawner>();
        rubbishLocationSpawner = rubbishSpawnerGameObject.GetComponent<RubbishLocationSpawner>();
        rubbishSpawner = rubbishSpawnerGameObject.GetComponent<RubbishSpawner>();
        scoreUpdateTriggerSpawner = scoreUpdateTriggerSpawnerGameObject.GetComponent<ScoreUpdateTriggerSpawner>();
        scoreIncrement = scoreIncrementGameObject.GetComponent<ScoreIncrement>();
        countdownTimer = countdownTimerGO.GetComponent<CountdownTimer>();
        playerMovement = playerMovementGO.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHandlingCollision) return; // Prevent multiple triggers

        isHandlingCollision = true;

        if (other.CompareTag("Ice Cream"))
        {
            Debug.Log("Ice Cream Detected");
            scoreIncrement.IceCreamScore();
            HandleRubbishDestructionAndSpawning(other.gameObject);
            countdownTimer.remainingTime += 10;
            playerMovement.walkSpeed += 1;
            playerMovement.runSpeed += 1;
        }
        else if (other.CompareTag("Cake"))
        {
            Debug.Log("Cake Detected");
            scoreIncrement.CakeScore();
            HandleRubbishDestructionAndSpawning(other.gameObject);
            countdownTimer.remainingTime += 12;
            playerMovement.walkSpeed += 2;
            playerMovement.runSpeed += 2;
        }
        if (other.CompareTag("Donut"))
        {
            Debug.Log("Donut Detected");
            scoreIncrement.DonutScore();
            HandleRubbishDestructionAndSpawning(other.gameObject);
            countdownTimer.remainingTime += 17;
            playerMovement.walkSpeed += 2;
            playerMovement.runSpeed += 2;
        }

        //isHandlingCollision = false;
    }

    private void HandleRubbishDestructionAndSpawning(GameObject rubbish)
    {
        // Destroy the existing trash and trash can
        Destroy(rubbish);
        Destroy(trashCanSpawner.spawnedTrashCan);

        // Generate a new random location for trash and trash can
        Transform newTrashCanSpawnLocation = trashCanLocationSpawner.GetSelectedTrashCanLocation();
        Transform newRubbishLocation = rubbishLocationSpawner.GetSelectedLocation();

        // Spawn new trash can and rubbish
        Debug.Log("Spawning New Trash Can");
        GameObject newTrashCan = trashCanSpawner.SpawnTrashCanOnMap(trashCanPrefab, newTrashCanSpawnLocation);

        // Spawn score update trigger plane and parent it to the new trash can
        Debug.Log("Cloning Plane at New Trash Can Location");
        scoreUpdateTriggerSpawner.ClonePlaneAtLocation(newTrashCan);
    }

    public void SetSpawnerReferences(GameObject trashCanSpawnerGO, GameObject rubbishSpawnerGO, GameObject scoreUpdateTriggerSpawnerGO, GameObject trashCanPrefab)
    {
        // Setting all the script variables to respective script files in project
        trashCanSpawnerGameObject = trashCanSpawnerGO;
        rubbishSpawnerGameObject = rubbishSpawnerGO;
        scoreUpdateTriggerSpawnerGameObject = scoreUpdateTriggerSpawnerGO;
        this.trashCanPrefab = trashCanPrefab;

        trashCanLocationSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanLocationSpawner>();
        trashCanSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanSpawner>();
        rubbishLocationSpawner = rubbishSpawnerGameObject.GetComponent<RubbishLocationSpawner>();
        rubbishSpawner = rubbishSpawnerGameObject.GetComponent<RubbishSpawner>();
        scoreUpdateTriggerSpawner = scoreUpdateTriggerSpawnerGameObject.GetComponent<ScoreUpdateTriggerSpawner>();
    }
}
