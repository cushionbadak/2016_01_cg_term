//#define DEBUG_MODE

using UnityEngine;
using System.Collections;

public class ObjectRotate : MonoBehaviour
{

    public float rotateSpeed;

    GameObject objInit;
    ObjectInit objIT;

    Vector3 yweight;

    // Use this for initialization
    void Start()
    {
        objInit = GameObject.Find("ObjectManager");
        objIT = objInit.GetComponent<ObjectInit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.orthographicSize < 0.002f || Camera.main.orthographicSize > 0.5)
        {
            return;
        }

#if (DEBUG_MODE)
        if (Input.GetKey(KeyCode.V))
        {
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
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 dp = Input.GetTouch(0).deltaPosition;
            Vector3 axis = new Vector3(0.0f, -1 * dp.x, 0.0f);
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
        //default rotation
        else
        {
            for (int i = 0; i < objIT.getSon(); i++)
            {
                foreach (Transform child in objIT.SmallOne[i].transform)
                {
                    child.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), rotateSpeed / (float)2.0, Space.World);
                }
            }
        }
    }
}
