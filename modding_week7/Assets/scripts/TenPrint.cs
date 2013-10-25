using UnityEngine;
using System.Collections;

public class TenPrint : MonoBehaviour {

    TextMesh myTextMesh;
    int counter = 0;

	// Use this for initialization
	void Start () {
        myTextMesh = GetComponent<TextMesh>();

        // built-in Unity shortcuts are actually calling GetComponent for you
        //Transform transform = GetComponent<Transform>();
        //Light light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

        float randomNumber = Random.Range( 0f, 10f );

        if ( randomNumber < 5f ) {
            myTextMesh.text += "/";
        } else {
            myTextMesh.text += "\\";
        }

        // everytime we print a character, we will increment the counter
        counter++;

        if ( counter % 50 == 0 ) {
            myTextMesh.text += "\n";
        }

	}
}
