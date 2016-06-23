using UnityEngine;
using System.Collections;

public class DirLightChange : MonoBehaviour {

    Light [] dr;
    Light whitelight;
    int count;
    float startTime;
    bool flag;

	// Use this for initialization
	void Start () {
        startTime = Time.time * 1000;
        dr = new Light[3];
        whitelight = GameObject.Find("WhiteLight").GetComponent<Light>();
        whitelight.intensity = 0.03f;
	    for (int i = 1; i< 4; i++)
        {
            dr[i - 1] = GameObject.Find("Directional light" + i).GetComponent<Light>();
        }
        count = 1;
        flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Time.time * 1000 > startTime + 500)
        {
            startTime = Time.time * 1000;
            int x = count % 3;
            float y = Random.Range(-0.05f, 0.05f);
            dr[x].intensity = y + 0.5f;
            
            //if (!flag)
            //{
            //    whitelight.intensity = 0.6f;
            //    flag = true;
            //}     
            //count++;
            
        }
        */
        /*
        if(flag && Time.time * 1000 > startTime + 50)
        {
            whitelight.intensity = 0.5f;
            flag = false;
        }
        */
	}
}
