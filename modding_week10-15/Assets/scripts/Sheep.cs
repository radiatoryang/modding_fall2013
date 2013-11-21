using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {

    // "public" does 2 things:
    // access in the editor, on per-sheep basis
    // it lets other scripts access this variable
    public int fame = 10;

    // first I need a reference to the particle system component
    public ParticleSystem fameParticles; // assign this in inspector

    void Start() {
        // if you put ParticleSystem with "AddComponent" on the same sheep obj
        // then you would GetComponent<>() instead
        // fameParticles = GetComponent<ParticleSystem>();

        // stuff one number into another number; Unity automatically
        // casts an integer ("fame") into emissionRate ("float")
        fameParticles.emissionRate = fame;

		// 11-21-2013: added navigation stuff, call "RandomRoam" every 10 seconds
		InvokeRepeating ( "RandomRoam", 1f, 10f );
    }

	void RandomRoam() {

		GetComponent<NavMeshAgent>().SetDestination ( Random.insideUnitSphere * 15f );
	}

    void Update() {
        // we can use PlayerInput.currentSheep without fetching a reference to it
        // because it is "public static", see PlayerInput.cs
        if ( PlayerInput.currentSheep == this ) {
            // if we are the current sheep, enable particles; otherwise, turn off
            fameParticles.enableEmission = true;
        } else {
            fameParticles.enableEmission = false;
        }

    }

}
