using UnityEngine;
using System.Collections;

public class DirLightChange : MonoBehaviour {

    Light [] dr;
    Light whitelight;
    int count;

	// Use this for initialization
	void Start () {
        dr = new Light[3];
        whitelight = GameObject.Find("WhiteLight").GetComponent<Light>();
        whitelight.intensity = 0.03f;
	    for (int i = 1; i< 4; i++)
        {
            dr[i - 1] = GameObject.Find("Directional light" + i).GetComponent<Light>();
        }
        count = 1;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            int x = count % 3;
            int y = count % 7;
            int z = count % 5;
            dr[x].intensity = (y + 1) * (0.05f) + 0.3f;
            whitelight.intensity = (z + 1) * (0.03f) + 0.2f;
            count++;
        }
	}
}
