using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    Vector3 destination = Vector3.zero;
    float stoppingDistance = 5f;
    float moveSpeed = 0.3f;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate() {
        // take distance to our destination; if further than __, then keep moving towards it
        if ( Vector3.Distance( transform.position, destination ) > stoppingDistance ) {
            rigidbody.AddForce( Vector3.Normalize( destination - transform.position ) * moveSpeed, ForceMode.VelocityChange );
        } else {
            // if we should stop, then add force in opposite direction of current velocity (brakes)
            rigidbody.AddForce( -rigidbody.velocity, ForceMode.Acceleration );
        }
    }
	
	// Update is called once per frame
	void Update () {
        // left-click sets new destination using raycast
        if ( Input.GetMouseButtonDown( 0 ) ) {
            // we only have to prep raycast IF the player left-clicked...

            // first, project mouse cursor onto camera matrix
            Ray mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
            // initialize Raycast impact info variable
            RaycastHit rayHit = new RaycastHit();

            if ( Physics.Raycast( mouseRay, out rayHit, 10000f ) ) {
                destination = rayHit.point;
            }
        }

    }

}
