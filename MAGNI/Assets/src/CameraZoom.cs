using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey("space")) {
            Camera.main.orthographicSize = (float)(0.98) * Camera.main.orthographicSize;
        }
	}
}
