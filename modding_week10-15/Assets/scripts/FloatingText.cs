using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {

	// "const" stands for "constant"
	// is an optimization that replaces the value / variable at compile-time
	// this value is NEVER going to change and CANNOT change, ever
	public const float speed = 2f;
	const float lifetime = 2f;

	// for METHOD 2, see below
	float birthTime = 0f;

	// Use this for initialization
	void Start () {
		// METHOD 1: use a "timer" by calling a coroutine
		StartCoroutine ( SelfDestruct () );

		// METHOD 2: keep a timer variable and check it in Update() constantly
		birthTime = Time.time;

		// METHOD 3: the laziest of them all and the easiest and the fairest of them all
		// will destroy / delete this object in "lifetime" seconds
		Destroy ( gameObject, lifetime );
	}
	
	// Update is called once per frame
	void Update () {
		// tells this floating text to always look at the Camera transform
		// affects ONLY rotation, to "look at" (face forward towards)
		transform.LookAt ( Camera.main.transform );

		// move this object up
		transform.position += transform.up * Time.deltaTime * speed;

		// METHOD 2: check whether it's been alive for too long
		if ( Time.time > birthTime + lifetime) {
			Destroy ( gameObject ); // ... then destroy it!
		}
	}

	// METHOD 1: a timer coroutine
	IEnumerator SelfDestruct () {
		yield return new WaitForSeconds( lifetime );
		Destroy ( gameObject );
	}
}
