using UnityEngine;
using System.Collections;

public class BallBounce : MonoBehaviour {

    Vector3 basePosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        basePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // this line of code is EXACTLY the same as the line of code after
        // basePosition = basePosition + new Vector3( 1.5f * Time.deltaTime, 0f, 0f );


        // makes a "basePosition" variable increase along the X axis
        basePosition += new Vector3( 100f * Time.deltaTime, 0f, 0f );

        // makes a ball hover using CODE, not with Unity's physics engine at all
        transform.position = basePosition + new Vector3( 0f, Mathf.Sin( Time.time * 2f ) * 5f, 0f );

        //transform.position += new Vector3( 0f , Mathf.Sin( Time.time * 2f ) * 5f, 0f );
        //transform.position += new Vector3( 3f * Time.deltaTime, 0f, 0f );
	}

    void OnTriggerEnter() {

    }
}
