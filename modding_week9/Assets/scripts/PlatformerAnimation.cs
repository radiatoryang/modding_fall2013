using UnityEngine;
using System.Collections;

public class PlatformerAnimation : MonoBehaviour {

    public Rigidbody myRigidbody; // assign in inspector

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        // if the player is moving
        if ( Input.GetAxis( "Vertical" ) != 0f ) {
            animation["Walk"].speed = myRigidbody.velocity.magnitude * 0.1f;
            animation.CrossFade( "Walk" );
        } else {
            animation.CrossFade( "Idle" );
        }


            // is the player holding down any buttons?
            // remember our last transform.position in a variable, then take our current one, compare distance
            // grab the rigidbody.velocity and look at magnitude

        // then use animation.CrossFade() to play the walk animation

        // ... ELSE, play idle animation

	}
}
