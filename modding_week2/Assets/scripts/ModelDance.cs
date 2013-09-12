using UnityEngine;
using System.Collections;

public class ModelDance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // just turn off the light when the game starts, in case we
        // forgot to turn off the light ourselves in the editor.
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        // if the game is over 2 seconds *AND* less than 10 seconds, then do this stuff...
        if ( Time.time > 2f && Time.time < 10f) {
            // this line of code here is THE SAME as the line of code BELOW...
            // transform.position = transform.position + new Vector3( 0f, 5f, 0f ) * Time.deltaTime;
            
            // this makes the model rise
            transform.position += new Vector3( 0f, 5f, 0f ) * Time.deltaTime;

            // this makes the model grow in size
            transform.localScale += new Vector3( 1f, 1f, 1f ) * Time.deltaTime;

            // this makes the model rotate
            transform.Rotate( 0f, 45f * Time.deltaTime, 0f );
            // this line of code is the same as the code above
            // transform.Rotate( new Vector3( 0f, 45f, 0f ) * Time.deltaTime );
        }

        // do NOT use "==" with floats, because Time.time might be 5.000001, and *never* equal exactly to 5
        // if (Time.time == 5f)

        // if 5 seconds have passed, and the light is off, then turn it on
        if ( Time.time >= 5f && light.enabled == false ) {
            light.enabled = true;
        }
	
	}
}
