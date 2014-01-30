using UnityEngine;
using System.Collections;

public class CamScroll : MonoBehaviour {
	float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			transform.position += Input.GetAxis ("Horizontal") * Vector3.right * Time.deltaTime * speed;
			transform.position += Input.GetAxis ("Vertical") * Vector3.forward * Time.deltaTime * speed;
	}
}
