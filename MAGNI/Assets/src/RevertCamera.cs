using UnityEngine;
using System.Collections;

public class RevertCamera : MonoBehaviour {

    const float threshold = 0.001f;
    const float initialCameraSize = 1.0f;

    void Start () {
        //void (?)
	}
	
	void Update () {
        //if Camera is zoomed to threshold
        if(Camera.main.orthographicSize < threshold)
        {
            // Camera revert
            Camera.main.orthographicSize = initialCameraSize;

        }
    }


}
