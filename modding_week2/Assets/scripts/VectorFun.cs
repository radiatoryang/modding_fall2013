using UnityEngine;
using System.Collections;

public class VectorFun : MonoBehaviour {

    // because it is PUBLIC, we can now tweak the destination from the inspector!
    public Vector3 destination = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // override the position
        // transform.position = new Vector3( 5f, 5f, 2f );

        // move constantly up
        // transform.position += new Vector3( 0f, 2f * Time.deltaTime, 0f );

        // move constantly towards Vector3 "destination"
        transform.position += ( destination - transform.position ) * Time.deltaTime;
	}
}
