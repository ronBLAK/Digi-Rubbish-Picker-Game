using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishLocationSpawner : MonoBehaviour
{
    [HideInInspector]
    public RubbishLocationStruct rubLocStruct = new RubbishLocationStruct(); // Holds the selected location info

    private Transform selectedLocation; // Variable to store the selected location

    int randomIndexRubbishLocation; // Stores the random index for selecting a location

    private List<RubbishLocationStruct> rubbishLocationList = new List<RubbishLocationStruct>(); // List to hold all rubbish locations

    [System.Serializable]
    public struct RubbishLocationStruct
    {
        public string locationLabel; // Placeholder name for easy identification of the location
        public Transform locationMarker; // The actual location marker to spawn the prefab
    }

    public RubbishLocationStruct[] rubbishLoc; // Array of RubbishLocationStruct

    public void Start()
    {
        // Add all elements from the rubbishLoc array to the rubbishLocationList
        rubbishLocationList.AddRange(rubbishLoc);
    }

    // Method to retrieve the selected location
    public Transform GetSelectedLocation()
    {
        // Generate a random index to select a location from the list
        randomIndexRubbishLocation = Random.Range(0, rubbishLocationList.Count);

        // Store the randomly selected location marker in the selectedLocation variable
        selectedLocation = rubbishLocationList[randomIndexRubbishLocation].locationMarker;

        // Assign the selected location to rubLocStruct
        rubLocStruct.locationMarker = selectedLocation;

        // Optionally log the selected location for debugging
        Debug.Log("Selected Location: " + selectedLocation.position);

        return selectedLocation;
    }
}
