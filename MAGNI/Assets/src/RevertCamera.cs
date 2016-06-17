using UnityEngine;
using System.Collections;

public class RevertCamera : MonoBehaviour {

    const float threshold = 0.001f;
    const float initialCameraSize = 1.0f;

    public GameObject prefab1;
    public GameObject prefab2;
    
    
    // Use this for initialization
    void Start () {
        //void (?)
	}
	
	// Update is called once per frame
	void Update () {
        //if Camera is zoomed to threshold
        if(Camera.main.orthographicSize < threshold)
        {
            Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
            // Camera revert
            Camera.main.orthographicSize = initialCameraSize;

            // Object change
            Destroy(GameObject.Find("BigOne"));
            Destroy(GameObject.Find("SmallOne"));
            Object bigone = Instantiate(prefab1, zero, Quaternion.identity);
            Object smallone = Instantiate(prefab2, zero, Quaternion.identity);
            bigone.name = "BigOne";
            smallone.name = "SmallOne";
            initializeBigOne(GameObject.Find("BigOne"));
            initializeSmallOne(GameObject.Find("SmallOne"));
        }
    }

    void initializeBigOne(GameObject obj)
    {
        Debug.Log("bigone in");
        foreach(Transform child in obj.transform)
        {
            Debug.Log("bigone");
            child.transform.localScale.Set(5.0f, 5.0f, 5.0f);
            child.transform.localPosition.Set(0.0f, 0.0f, 20.0f);
        }
    }

    void initializeSmallOne(GameObject obj)
    {
        Debug.Log("smallone in");
        foreach (Transform child in obj.transform)
        {
            Debug.Log("smallone");
            child.transform.localScale.Set(0.005f, 0.005f, 0.005f);
            child.transform.localPosition.Set(0.0f, 0.0f, 10.0f);
        }
    }
}
