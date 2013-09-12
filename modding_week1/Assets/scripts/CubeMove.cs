using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

    public float speed = 10f;
    public string secret = "I pick my nose.";
    public string notMySecret = "I bite my toenails and slurp them.";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // This code makes my cube go to cube heaven at a rate of 5 units over the duration of a second
        transform.position = transform.position + new Vector3( 0f, speed * Time.deltaTime, 0f );
	
        
    }
}
