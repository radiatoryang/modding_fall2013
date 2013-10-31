using UnityEngine;
using System.Collections;

public class WaterDeform : MonoBehaviour {

    MeshFilter mf;
    public float waveHeight = 0.001f;
    public float waveWidth = 2f;

    Vector3[] baseVertices;
    Vector3[] workingCopy;

	// Use this for initialization
	void Start () {
        mf = GetComponent<MeshFilter>();
        baseVertices = mf.mesh.vertices;
        workingCopy = baseVertices; // initialize / reserve space in memory
	}
	
	// Update is called once per frame
	void Update () {
        // go through every vertex in this model
        for ( int i = 0; i < workingCopy.Length; i++ ) {
            // and move it either up or down according to the sine wave
            workingCopy[i] = baseVertices[i] + Vector3.up * Mathf.Sin( Time.time * waveWidth + i ) * waveHeight;
        }

        // stuff data back into meshFilter
        mf.mesh.vertices = workingCopy;

        // recalculate normals ("normal" = the direction a polygon is facing)
        mf.mesh.RecalculateNormals();

        // OPTIONAL: visualize normals
        for ( int i = 0; i < mf.mesh.vertices.Length; i++ ) {
            Debug.DrawRay( transform.TransformPoint(mf.mesh.vertices[i]), mf.mesh.normals[i] );
        }

	}
}
