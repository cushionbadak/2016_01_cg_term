using UnityEngine;
using System.Collections;

public class RevertCamera : MonoBehaviour {

    const float threshold = 0.0002f;
    const float initialCameraSize = 1.0f;

    GameObject objInit;
    ObjectInit objIT;

    void Start () {
        objInit = GameObject.Find("ObjectManager");
        objIT = objInit.GetComponent<ObjectInit>();
    }
	
	void Update () {
        //if Camera is zoomed to threshold
        if(Camera.main.orthographicSize < threshold)
        {
            // Camera revert
            Camera.main.orthographicSize = initialCameraSize;
            objIT.InitNew();
        }
    }


}
