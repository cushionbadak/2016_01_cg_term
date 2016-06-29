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
        // stop camera rotation for short time
        if(Camera.main.orthographicSize < 0.002f || Camera.main.orthographicSize > 0.5)
        {
            return;
        }
        // rotate object when touched
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 dp = Input.GetTouch(0).deltaPosition;
            Vector3 axis = new Vector3(0.0f, -1 * dp.x, 0.0f);
            int index = objIT.getCurIndex();
            int son_sqr = objIT.getSon();
            int tt = index * son_sqr;
            for (int i = tt; i < tt + son_sqr; i++)
            {
                foreach (Transform child in objIT.SmallOne[i].transform)
                {
                    child.transform.Rotate(axis, rotateSpeed, Space.World);
                }
            }
        }
        //default rotation
        else
        {
            int index = objIT.getCurIndex();
            int son_sqr = objIT.getSon();
            int tt = index * son_sqr;
            for (int i = tt; i < tt + son_sqr; i++)
            {
                foreach (Transform child in objIT.SmallOne[i].transform)
                {
                    child.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), rotateSpeed / (float)4.0, Space.World);
                }
            }
        }
    }
}
