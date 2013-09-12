using UnityEngine;
using System.Collections;

// because CameraSpin has NOTHING TO DO WITH ModelDance, and does a different job,
// I am putting this code in a separate script file!
public class CameraSpin : MonoBehaviour {

    // this is PUBLIC, exposed in the inspector, and now I can tweak it in-game very easily
    public float rotateSpeed = 45f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // look at how simple this code is! wow!
        transform.Rotate( 0f, rotateSpeed * Time.deltaTime, 0f );
	}
}
