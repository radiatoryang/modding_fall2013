using UnityEngine;
using System.Collections;

public class NpcBot : MonoBehaviour {

    public GUIText scoreText;
    public TextMesh npcDialog;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // shoot a short raycast in front of us; if there's a wall, turn 90 degrees
        if ( Physics.Raycast( transform.position, transform.forward, 2f) ) {
            // 50% chance to rotate left, 50% to rotate right
            int randomNumber = Random.Range(0, 10);
            if ( randomNumber < 5 ) {
                transform.Rotate(0f, -90f, 0f);
            }
            else {
                transform.Rotate( 0f, 90f, 0f );
            }
        }

        scoreText.color = new Color( Random.value, Random.value, Random.value );
        npcDialog.text = "Hey I love you";
	}

    void FixedUpdate() {
        // always walk forward, relative to where I'm facing
        rigidbody.AddForce( transform.forward * 10f );

        // you can also do: rigidbody.AddRelativeForce ( Vector3.forward );
    }

}
