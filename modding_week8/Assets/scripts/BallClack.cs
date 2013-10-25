using UnityEngine;
using System.Collections;

public class BallClack : MonoBehaviour {

    public Vector3 start, end; // exposed in the inspector

    Vector3 baseCameraPosition;

	// Use this for initialization
	void Start () {
        StartCoroutine( BallMove() );
        baseCameraPosition = Camera.main.transform.position;
	}

    // again, this coroutine should NOT be here, ScreenShake has NOTHING to do with BallClack, it confuses us
    IEnumerator ScreenShake() {
        float t = 1f;
       
        while ( t > 0f ) {
            t -= Time.deltaTime;
            Camera.main.transform.position = baseCameraPosition + t *
                                             new Vector3( Mathf.Sin( Time.time * 10f ), 
                                                          Mathf.Sin( Time.time * 12.5f ), 
                                                          Mathf.Sin( Time.time * 7f ) ) ;
            yield return 0;
        }
        Camera.main.transform.position = baseCameraPosition;
    }

    IEnumerator BallMove() {

        while ( true ) {
            float t = Mathf.Abs( Mathf.Sin( Time.time ) );
            if ( t < 0.6f && t > 0.4f && audio.isPlaying == false) {
                audio.Play();
                StartCoroutine( ScreenShake() ); // we should put this in a separate script file; ScreenShake != BallClack
            }
            transform.position = Vector3.Lerp( start, end, t );
            yield return 0; // wait a frame
        }

        // the code below here will NEVER RUN
        // because the while(true) loop is INFINITE

        yield return 0; // waits one frame
        Debug.Log( "I waited one frame" );

        yield return 0;
        yield return 0; // waits two frames
        Debug.Log( "I waited two frames" );

        yield return new WaitForSeconds( 5f ); // waits X seconds
        Debug.Log( "5 seconds have passed" );
    }

}
