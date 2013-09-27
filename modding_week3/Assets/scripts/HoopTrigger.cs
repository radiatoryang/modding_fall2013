using UnityEngine;
using System.Collections;

public class HoopTrigger : MonoBehaviour {

    public int health = 100;

    public Light sun; // assign sun in inspector

	// Use this for initialization
	void Start () {
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}


    void OnTriggerEnter() 
    {
        light.enabled = true;
        sun.enabled = false;
    }

}
