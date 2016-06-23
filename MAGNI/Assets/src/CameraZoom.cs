//#define DEBUG_MODE

using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float defaultspeed;
    public float clickspeed;
    private float startTime;
    private float nowTime;
    private bool flag;

	void Start () {
        startTime = Time.time * 1000;
        flag = false;
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

        nowTime = Time.time * 1000;

        if (nowTime > startTime + 950 && !flag)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize * 0.9f;
            startTime = nowTime;
            flag = true;
        }
        else if (flag && nowTime > startTime + 70)
        {
            flag = false;
            Camera.main.orthographicSize = Camera.main.orthographicSize * 1.03f;
        }
	}
}
//Input.GetKey("space") || 
// && Input.GetTouch(0).phase == TouchPhase.Moved