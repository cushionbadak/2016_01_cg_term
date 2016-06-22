using UnityEngine;
using System.Collections;

public class DirLightChange : MonoBehaviour {

    GameObject[] dr;
    int count;
    public float bright;
    public float deem;

	// Use this for initialization
	void Start () {
        dr = new GameObject[3];
	    for (int i = 1; i< 4; i++)
        {
            dr[i - 1] = GameObject.Find("Directional light" + i);
            count = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            int x = count % 3;
            int y = count % 7;
            (dr[x].GetComponent<Light>()).intensity = (y + 1) * (0.1f);
            
            count++;
        }
	}
}
