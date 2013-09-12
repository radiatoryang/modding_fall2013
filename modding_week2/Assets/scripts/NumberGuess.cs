using UnityEngine;
using System.Collections;

public class NumberGuess : MonoBehaviour {

    int guess = 0; // this is the number the player is guessing

    int secretNumber = 0; // this is the number we have to guess

	// Use this for initialization
	void Start () {
        // generate a random number from 0 to 20
        secretNumber = Random.Range( 0, 21 );
	}
	
	// Update is called once per frame
	void Update () {
        

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            guess = guess - 1;
            guiText.text = guess.ToString(); // update GUI
        }

        if ( Input.GetKeyUp( KeyCode.RightArrow ) ) {
            // these two ways of incrementing the guess are THE SAME as the third line down:
            // guess = guess + 1;
            // guess++;
            guess += 1;
            guiText.text = guess.ToString(); // update GUI
        }

        // if player presses enter, then evaluate the guess
        if ( Input.GetKeyDown( KeyCode.Return ) ) {
            if ( guess < secretNumber ) 
                { guiText.text = "your guess was too low"; } // we can put curly braces all on one line too
                
            else if ( guess > secretNumber ) {
                guiText.text = "your guess was too high";
            } else {
                guiText.text = "YOU WIN, YOU ARE THE BEST";
            }

        }
	}
}
