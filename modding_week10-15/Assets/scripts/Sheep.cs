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

        fameParticles.emissionRate = fame;
    }

    void Update() {
        // if we are the current sheep, enable particles; otherwise, turn off
        if ( PlayerInput.currentSheep == this ) {
            fameParticles.enableEmission = true;
        } else {
            fameParticles.enableEmission = false;
        }

    }

}
