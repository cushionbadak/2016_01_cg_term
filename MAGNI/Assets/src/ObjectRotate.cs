//#define DEBUG_MODE

using UnityEngine;
using System.Collections;

public class ObjectRotate : MonoBehaviour
{

    public float rotateSpeed;

    GameObject objInit;
    ObjectInit objIT;

    // Use this for initialization
    void Start()
    {
        objInit = GameObject.Find("ObjectManager");
        objIT = objInit.GetComponent<ObjectInit>();
    }

    // Update is called once per frame
    void Update()
    {
#if (DEBUG_MODE)
        Vector2 dp = new Vector2(1.0f, 1.0f);
        Vector3 axis = new Vector3(dp.y, -1 * dp.x, 0.0f);
        //foreach(Transform child in objIT.BigOne.transform)
        //{
        //    child.transform.Rotate(axis, rotateSpeed, Space.Self);
        //}
        for (int i = 0; i < objIT.getSon(); i++)
        {
            foreach (Transform child in objIT.SmallOne[i].transform)
            {
                child.transform.Rotate(axis, rotateSpeed, Space.Self);
            }
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 dp = Input.GetTouch(0).deltaPosition;
            Vector3 axis = new Vector3(dp.y, -1 * dp.x, 0.0f);
            //foreach (Transform child in objIT.BigOne.transform)
            //{
            //    child.transform.Rotate(axis, rotateSpeed, Space.World);
            //}
            for (int i = 0; i < objIT.getSon(); i++)
            {
                foreach (Transform child in objIT.SmallOne[i].transform)
                {
                    child.transform.Rotate(axis, rotateSpeed, Space.World);
                }
            }
        }
#endif
    }
}
