using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // if I detect the left-click then load the next level
        // in this case, the next level is the scene that actually has the game in it
        if ( Input.GetMouseButtonDown( 0 ) ) {
            Application.LoadLevel( 1 );
        }
	}
}
