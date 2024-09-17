using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DestroyAndSpawnNewTrashAndTrashCan : MonoBehaviour
{
    // References to various script components for game management
    private ScoreIncrement scoreIncrement;
    private CountdownTimer countdownTimer;
    private PlayerMovement playerMovement;

    // GameObjects holding references to score, timer, and player movement
    public GameObject scoreIncrementGameObject;
    public GameObject countdownTimerGO;
    public GameObject playerMovementGO;

    // Prefab for the trash can to spawn
    public GameObject trashCanPrefab;

    // References to GameObjects that manage the spawning of trash and trash cans
    public GameObject trashCanSpawnerGameObject;
    public GameObject rubbishSpawnerGameObject;
    public GameObject scoreUpdateTriggerSpawnerGameObject;

    // Script components that handle spawning mechanics
    private TrashCanLocationSpawner trashCanLocationSpawner;
    private TrashCanSpawner trashCanSpawner;
    private RubbishLocationSpawner rubbishLocationSpawner;
    private RubbishSpawner rubbishSpawner;
    private ScoreUpdateTriggerSpawner scoreUpdateTriggerSpawner;

    private bool isHandlingCollision = false; // Flag to prevent multiple collision handling

    private void Start()
    {
        // Initialize the script components by fetching them from the GameObjects
        trashCanLocationSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanLocationSpawner>();
        trashCanSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanSpawner>();
        rubbishLocationSpawner = rubbishSpawnerGameObject.GetComponent<RubbishLocationSpawner>();
        rubbishSpawner = rubbishSpawnerGameObject.GetComponent<RubbishSpawner>();
        scoreUpdateTriggerSpawner = scoreUpdateTriggerSpawnerGameObject.GetComponent<ScoreUpdateTriggerSpawner>();
        scoreIncrement = scoreIncrementGameObject.GetComponent<ScoreIncrement>();
        countdownTimer = countdownTimerGO.GetComponent<CountdownTimer>();
        playerMovement = playerMovementGO.GetComponent<PlayerMovement>();
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        if (isHandlingCollision) return; // Prevent handling multiple triggers simultaneously

        isHandlingCollision = true; // Set flag to true to indicate collision is being handled

        // Check the tag of the collided object to perform specific actions
        if (other.CompareTag("Ice Cream"))
        {
            Debug.Log("Ice Cream Detected");
            scoreIncrement.IceCreamScore(); // Increment score for ice cream
            HandleRubbishDestructionAndSpawning(other.gameObject); // Handle destruction and spawning
            countdownTimer.remainingTime += 10; // Add time to the countdown
            playerMovement.walkSpeed += 1; // Increase player walk speed
            playerMovement.runSpeed += 1; // Increase player run speed
        }
        else if (other.CompareTag("Cake"))
        {
            Debug.Log("Cake Detected");
            scoreIncrement.CakeScore(); // Increment score for cake
            HandleRubbishDestructionAndSpawning(other.gameObject); // Handle destruction and spawning
            countdownTimer.remainingTime += 12; // Add time to the countdown
            playerMovement.walkSpeed += 2; // Increase player walk speed
            playerMovement.runSpeed += 2; // Increase player run speed
        }
        else if (other.CompareTag("Donut"))
        {
            Debug.Log("Donut Detected");
            scoreIncrement.DonutScore(); // Increment score for donut
            HandleRubbishDestructionAndSpawning(other.gameObject); // Handle destruction and spawning
            countdownTimer.remainingTime += 17; // Add time to the countdown
            playerMovement.walkSpeed += 2; // Increase player walk speed
            playerMovement.runSpeed += 2; // Increase player run speed
        }

        // Uncomment this if you want to reset the collision flag after handling
        // isHandlingCollision = false;
    }

    // Handles the destruction of the current rubbish and trash can, and spawns new ones
    private void HandleRubbishDestructionAndSpawning(GameObject rubbish)
    {
        // Destroy the current rubbish and the spawned trash can
        Destroy(rubbish);
        Destroy(trashCanSpawner.spawnedTrashCan);

        // Get new locations for spawning the trash can and rubbish
        Transform newTrashCanSpawnLocation = trashCanLocationSpawner.GetSelectedTrashCanLocation();
        Transform newRubbishLocation = rubbishLocationSpawner.GetSelectedLocation();

        // Spawn new trash can at the new location
        Debug.Log("Spawning New Trash Can");
        GameObject newTrashCan = trashCanSpawner.SpawnTrashCanOnMap(trashCanPrefab, newTrashCanSpawnLocation);

        // Spawn a score update trigger plane and attach it to the new trash can
        Debug.Log("Cloning Plane at New Trash Can Location");
        scoreUpdateTriggerSpawner.ClonePlaneAtLocation(newTrashCan);
    }

    // Sets the references to the spawner GameObjects and their respective components
    public void SetSpawnerReferences(GameObject trashCanSpawnerGO, GameObject rubbishSpawnerGO, GameObject scoreUpdateTriggerSpawnerGO, GameObject trashCanPrefab)
    {
        // Assign the spawner GameObjects
        trashCanSpawnerGameObject = trashCanSpawnerGO;
        rubbishSpawnerGameObject = rubbishSpawnerGO;
        scoreUpdateTriggerSpawnerGameObject = scoreUpdateTriggerSpawnerGO;
        this.trashCanPrefab = trashCanPrefab;

        // Initialize the script components by fetching them from the GameObjects
        trashCanLocationSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanLocationSpawner>();
        trashCanSpawner = trashCanSpawnerGameObject.GetComponent<TrashCanSpawner>();
        rubbishLocationSpawner = rubbishSpawnerGameObject.GetComponent<RubbishLocationSpawner>();
        rubbishSpawner = rubbishSpawnerGameObject.GetComponent<RubbishSpawner>();
        scoreUpdateTriggerSpawner = scoreUpdateTriggerSpawnerGameObject.GetComponent<ScoreUpdateTriggerSpawner>();
    }
}
