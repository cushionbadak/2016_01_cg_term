using UnityEngine;
using System.Collections;

public class RevertCamera : MonoBehaviour {

    const float threshold = 0.001f;
    const float initialCameraSize = 1.0f;

    GameObject objInit;
    ObjectInit objIT;
    GameManager gm;

    void Start () {
        objInit = GameObject.Find("ObjectManager");
        objIT = objInit.GetComponent<ObjectInit>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {
        //if Camera is zoomed to threshold
        if(Camera.main.orthographicSize < threshold)
        {
            // Scoring
            foreach (Transform child in GameObject.Find("SmallOne0").transform)
            {
                gm.writeScore(child.eulerAngles.y < 200.0f && child.eulerAngles.y > 160.0f);
                break;
            }
                
            // Camera revert
            Camera.main.orthographicSize = initialCameraSize;

            // Object Init
            objIT.InitNew();

        }
    }


}
