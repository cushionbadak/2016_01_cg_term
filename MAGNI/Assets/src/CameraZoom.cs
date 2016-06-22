//#define DEBUG_MODE

using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float defaultspeed;
    public float clickspeed;
	void Start () {

	}
	
	void Update () {
        // default zoom
        Camera.main.orthographicSize = (defaultspeed) * Camera.main.orthographicSize;
#if (DEBUG_MODE)
        if (Input.GetKey(KeyCode.Space))
        {
            Camera.main.orthographicSize = (clickspeed) * Camera.main.orthographicSize;
        }
#endif
        if(Input.touchCount > 0) {
            Camera.main.orthographicSize = (clickspeed) * Camera.main.orthographicSize;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
//Input.GetKey("space") || 
// && Input.GetTouch(0).phase == TouchPhase.Moved