using UnityEngine;
using System.Collections;
using System.Collections.Generic; // YOU NEED THIS LINE TO USE LISTS

public class FishGod : MonoBehaviour {

    public Fish fishBlueprint; // assign in inspector
    public int fishCount = 100;

    public List<Fish> fishList = new List<Fish>(); // you must initialize lists to use them

	// Use this for initialization
	void Start () {
        int currentFishCounter = 0;

        // WHILE loop: as long as whatever inside the ( ) is "true", it will looping through the code
	    while ( currentFishCounter < fishCount ) {
            // first, let's generate a fish clone position
            Vector3 fishPosition = Random.insideUnitSphere * 100f;

            // now let's spawn our fish clone, based off our blueprint
            Fish newFish = Instantiate( fishBlueprint, fishPosition, Quaternion.identity ) as Fish;
            // add the fish to our fish list, so we can do stuff with it later
            fishList.Add( newFish );        

            // increment our fishCounter; if we forget this step, it will be an INFINITE LOOP which is bad!
            currentFishCounter++;
        }

        // when currentFishCounter == 100, then the while() statement will no longer be true
        // and thus it will end the while() loop and not loop through the code anymore!

        // ... and it will move on, and do whatever code we put after it... like right here!
	}
	
	// Update is called once per frame
	void Update () {

        // if the player presses down spacebar, then...
        if ( Input.GetKeyDown( KeyCode.Space ) ) {

            // go through the entire list of fish, and for each fish, set that fish's destination to 0, 0, 0
            foreach ( Fish currentFish in fishList ) {
                currentFish.destination = Vector3.zero;
            }

        }


	}
}
