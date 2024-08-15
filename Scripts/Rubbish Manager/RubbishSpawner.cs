using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishSpawner : RubbishLocationSpawner
{

    int randomIndexRubbishType;

    RubbishTypesStruct randomRubbishType;

    private GameObject spawnedRubbish; // Reference to the spawned rubbish prefab

    private List<RubbishTypesStruct> rubbishTypesList = new List<RubbishTypesStruct>();

    [System.Serializable]
    public struct RubbishTypesStruct
    {
        public string rubbishname;
        public GameObject rubbishObjectModel;
    }

    public RubbishTypesStruct[] rubbishTypes;
    
    public void Update()
    {
        // Check if there is already a spawned rubbish prefab
        if (spawnedRubbish == null)
        {
            // Spawn a new rubbish prefab
            SpawnRubbishOnMap(SelectRandomRubbishType().rubbishObjectModel, GetSelectedLocation());
        }
    }

    public RubbishTypesStruct SelectRandomRubbishType()
    {
        rubbishTypesList.AddRange(rubbishTypes);

        randomIndexRubbishType = Random.Range(0, rubbishTypesList.Count);

        randomRubbishType = rubbishTypesList[randomIndexRubbishType];

        return randomRubbishType;
    }

    public GameObject SpawnRubbishOnMap(GameObject rubbishType, Transform rubbishPos)
    {
        // Instantiate the rubbish prefab and store the reference
        spawnedRubbish = Instantiate(rubbishType, rubbishPos.position, Quaternion.identity);
        return spawnedRubbish;
    }
}
