using UnityEngine;
using System.Collections;

public class WaterScroll : MonoBehaviour {

    // this code is ripped almost entirely from the Unity documentation for Material.mainTextureOffset
    public float scrollSpeed = 0.5f;

    void Update() {
        float offset = Time.time * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(-offset, Mathf.Sin(offset * 2f) ); 
    }
}
