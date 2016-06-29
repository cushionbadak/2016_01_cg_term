using UnityEngine;
using System.Collections;

public class RevertCamera : MonoBehaviour {

    const float threshold = 0.001f;
    const float initialCameraSize = 1.0f;

    GameObject objInit;
    ObjectInit objIT;
    GameManager gm;
    UIManager um;

    void Start () {
        objInit = GameObject.Find("ObjectManager");
        objIT = objInit.GetComponent<ObjectInit>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        um = GameObject.Find("Text").GetComponent<UIManager>();
    }
	
	void Update () {
        //if Camera is zoomed to threshold
        if(Camera.main.orthographicSize < threshold)
        {
            int tt = objIT.getCurIndex() * objIT.getSon();
            // Scoring
            foreach (Transform child in GameObject.Find("SmallOne" + tt).transform)
            {
                gm.writeScore(child.eulerAngles.y < 210.0f && child.eulerAngles.y > 150.0f);
                break;
            }
            um.updateScore();
                
            // Camera revert
            Camera.main.orthographicSize = initialCameraSize;

            // Object Init
            objIT.InitNew();

        }
    }


}
