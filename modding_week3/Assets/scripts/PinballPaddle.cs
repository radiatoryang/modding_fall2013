using UnityEngine;
using System.Collections;

public class PinballPaddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ( Input.GetKey( KeyCode.LeftArrow ) ) {
                rigidbody.AddTorque( 0f, 90000f, 0f ); 
        } else {
                rigidbody.AddTorque( 0f, -90000f, 0f ); 
        }
	}
}
