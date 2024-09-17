using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishSpawner : RubbishLocationSpawner
{
    int randomIndexRubbishType; // Index for selecting a random rubbish type

    RubbishTypesStruct randomRubbishType; // Stores the selected rubbish type

    private GameObject spawnedRubbish; // Reference to the spawned rubbish prefab

    private List<RubbishTypesStruct> rubbishTypesList = new List<RubbishTypesStruct>(); // List to hold all rubbish types

    [System.Serializable]
    public struct RubbishTypesStruct
    {
        public string rubbishname; // Name of the rubbish type
        public GameObject rubbishObjectModel; // The actual GameObject model of the rubbish
    }

    public RubbishTypesStruct[] rubbishTypes; // Array of RubbishTypesStruct

    public void Update()
    {
        // Check if there is no spawned rubbish prefab
        if (spawnedRubbish == null)
        {
            // Spawn a new rubbish prefab at the selected location
            SpawnRubbishOnMap(SelectRandomRubbishType().rubbishObjectModel, GetSelectedLocation());
        }
    }

    // Method to select a random rubbish type
    public RubbishTypesStruct SelectRandomRubbishType()
    {
        rubbishTypesList.AddRange(rubbishTypes); // Add all rubbish types to the list

        // Generate a random index to select a rubbish type from the list
        randomIndexRubbishType = Random.Range(0, rubbishTypesList.Count);

        // Store the randomly selected rubbish type
        randomRubbishType = rubbishTypesList[randomIndexRubbishType];

        return randomRubbishType;
    }

    // Method to spawn a rubbish prefab at a given location
    public GameObject SpawnRubbishOnMap(GameObject rubbishType, Transform rubbishPos)
    {
        // Instantiate the rubbish prefab at the specified position and store the reference
        spawnedRubbish = Instantiate(rubbishType, rubbishPos.position, Quaternion.identity);
        return spawnedRubbish;
    }
}
