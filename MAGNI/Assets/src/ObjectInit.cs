using UnityEngine;
using System.Collections;

public class ObjectInit : MonoBehaviour {

    public Object bigbig, smallsmall;
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

        bigbig = Instantiate(plist.getObj(count++), zero, Quaternion.identity);
        smallsmall = Instantiate(plist.getObj(count++), zero, Quaternion.identity);
        bigbig.name = "BigOne";
        smallsmall.name = "SmallOne";
        BigOne = GameObject.Find("BigOne");
        SmallOne = GameObject.Find("SmallOne");
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    void InitNew()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

        Destroy(BigOne);
        Destroy(SmallOne);
        bigbig = Instantiate(smallsmall, zero, Quaternion.identity);
        smallsmall = Instantiate(plist.getObj(count++), zero, Quaternion.identity);
        bigbig.name = "BigOne";
        smallsmall.name = "SmallOne";
        BigOne = GameObject.Find("BigOne");
        SmallOne = GameObject.Find("SmallOne");
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    void initializeBigOne(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            child.transform.localScale.Set(5.0f, 5.0f, 5.0f);
            child.transform.localPosition.Set(0.0f, 0.0f, 20.0f);
        }
    }

    void initializeSmallOne(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            child.transform.localScale.Set(0.005f, 0.005f, 0.005f);
            child.transform.localPosition.Set(0.0f, 0.0f, 10.0f);
        }
    }
}
