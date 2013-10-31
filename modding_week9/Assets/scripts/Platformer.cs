using UnityEngine;
using System.Collections;

// 3D platformer, Mario 64
// first, for camera: parent the camera behind the player, in-editor
public class Platformer : MonoBehaviour {

    Vector3 inputVector;
    public float speed = 0.8f;
    public float turnSpeed = 90f;
    public float jumpSpeed = 1000f;
    public float fallSpeed = 6f;
    bool grounded = false;

    void Update() {
        // we put the sum total of all the player's movement inputs into "inputVector"
        // before passing on the input info to FixedUpdate, which is what actually moves the player
        inputVector = Vector3.zero;

        // movement: move forward, back
        if ( Input.GetKey( KeyCode.W ) ) { // MOVE FORWARD
            inputVector += transform.forward;   // transform.forward does NOT move anything, it is just a variable we read
        }
        if ( Input.GetKey( KeyCode.S ) ) { // MOVE BACKWARD
            inputVector += -transform.forward;
        }
        // turning: left and right
        if ( Input.GetKey( KeyCode.A ) ) {
            transform.Rotate( 0f, -turnSpeed * Time.deltaTime, 0f );
        }
        if ( Input.GetKey( KeyCode.D ) ) {
            transform.Rotate( 0f, turnSpeed * Time.deltaTime, 0f );
        }
        // movement: jumping? how to jump?
        if ( Physics.Raycast( transform.position, -transform.up, 1.3f ) == true ) {
            grounded = true;
            if ( Input.GetKeyDown( KeyCode.Space ) ) {
                inputVector += Vector3.up * jumpSpeed;
            }
        } else {
            grounded = false;
        }
    }

    void FixedUpdate() {
        // we apply physics forces in FixedUpdate
        if ( inputVector != Vector3.zero ) {
            rigidbody.AddForce( inputVector * speed, ForceMode.VelocityChange );
        } else {
            rigidbody.AddForce( -rigidbody.velocity, ForceMode.Acceleration ); // brake, stopping force
        }
    }
}