using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    public Vector3 destination = new Vector3( 100f, 100f, 0f );
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        // keep repeating _____ function, after delay of 0 s, repeat every 15 seconds
        InvokeRepeating( "SetNewDestination", 0f, 15f );
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation( rigidbody.velocity );
	}

    void FixedUpdate() {
        Vector3 direction = Vector3.Normalize( destination - transform.position );
        rigidbody.AddForce( direction * speed, ForceMode.Acceleration);
    }

    public void SetNewDestination() {
        // set a random destination
        SetNewDestination( Random.insideUnitSphere * 100f );

        // we call SetNewDestination() overload instead of re-assigning "destination" directly
        // because this is good engineering practice!

        // imagine if we wanted to play a sound every time the fish changed its destination;
        // where you would put the "audio.Play()" instruction?

        // if we have one function overload feed into another, that means we only have to
        // put "audio.Play()" in the 2nd overload, because all the other overloads feed into that
        
        // if we did NOT have the functions feeding into each other, then it would have to put
        // "audio.Play()" in one version and the other, and that code is harder to maintain...
        // ... but it shouldn't be harder to maintain, because we're just doing the same thing, twice!
    }

    public void SetNewDestination (Vector3 newDestination) {
        destination = newDestination;
    }
}
