using UnityEngine;
using System.Collections;

public class ObjectInit : MonoBehaviour {

    //public Object bigbig, smallsmall;
    public GameObject BigOne, SmallOne;
    public int smallObjNum;
    private int son_sqr;
    private int count;

    GameObject prefablist;
    PrefabList plist;

    // Use this for initialization
    void Start () {
        son_sqr = smallObjNum * smallObjNum;
        count = 0;
        prefablist = GameObject.Find("PrefabList");
        plist = prefablist.GetComponent<PrefabList>();
        First();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void First()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        
        BigOne = Instantiate(plist.getObj(count++), zero, Quaternion.identity) as GameObject;
        SmallOne = Instantiate(plist.getObj(count++), zero, Quaternion.identity) as GameObject;
        BigOne.name = "BigOne";
        SmallOne.name = "SmallOne";
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    public void InitNew()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

        Destroy(BigOne);
        BigOne = Instantiate(plist.getObj(count - 1), zero, Quaternion.identity) as GameObject;
        Destroy(SmallOne);
        SmallOne = Instantiate(plist.getObj(count++), zero, Quaternion.identity) as GameObject;

        BigOne.name = "BigOne";
        SmallOne.name = "SmallOne";
        
        
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    void initializeBigOne(GameObject obj)
    {
        //Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject obj = GameObject.Find("BigOne");
        //GameObject obj2 = Instantiate(obj, zero, Quaternion.identity) as GameObject;
        foreach (Transform child in obj.transform)
        {
            child.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            child.transform.localPosition = new Vector3(0.0f, 0.0f, 20.0f);
        }
    }

    void initializeSmallOne(GameObject obj)
    {
        //Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject obj = GameObject.Find("SmallOne");
        //GameObject obj2 = Instantiate(obj, zero, Quaternion.identity) as GameObject;
        foreach (Transform child in obj.transform)
        {
            child.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            child.transform.localPosition = new Vector3(0.0f, 0.0f, 10.0f);
        }
    }
}
