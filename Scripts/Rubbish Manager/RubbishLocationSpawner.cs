using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishLocationSpawner : MonoBehaviour
{
    [HideInInspector]
    public RubbishLocationStruct rubLocStruct = new RubbishLocationStruct();

    // Variable to store the selected location
    private Transform selectedLocation;

    // this stores a random number ranging from 0 to the number of items in the 
    int randomIndexRubbishLocation;

    // this is the list where all the locations are transferred to from the struct
    private List<RubbishLocationStruct> rubbishLocationList = new List<RubbishLocationStruct>();

    [System.Serializable]
    public struct RubbishLocationStruct
    {
        public string locationLabel; // inside the struct, this property is a placeholder name for the location for easy identification
        public Transform locationMarker; // inside the struct, this is where the actual location to spawn the prefab is stored
    }

    public RubbishLocationStruct[] rubbishLoc;

    public void Start()
    {
        rubbishLocationList.AddRange(rubbishLoc); // adds all the items in the struct to the list
    }

    // Method to retrieve the selected location
    public Transform GetSelectedLocation()
    {
        randomIndexRubbishLocation = Random.Range(0, rubbishLocationList.Count); // generate a random idex number to pass into the list index to pick the random element from the list

        // Store the randomly selected location in the variable
        selectedLocation = rubbishLocationList[randomIndexRubbishLocation].locationMarker;

        // Assign the selected location to rubLocStruct
        rubLocStruct.locationMarker = selectedLocation;

        // Optionally, you can log the selected location for debugging
        Debug.Log("Selected Location: " + selectedLocation.position);

        return selectedLocation;
    }
}