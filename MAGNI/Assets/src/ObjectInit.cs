#define SEQUENCE_MODE

using UnityEngine;
using System.Collections;

public class ObjectInit : MonoBehaviour {

    //public Object bigbig, smallsmall;
    public GameObject BigOne;
    public GameObject[] SmallOne;
    public int smallObjNum;
    private int son_sqr;
    private int count;
    private int prev_count;
    private int objsLen;
    private Quaternion prev_qt;

    GameObject prefablist;
    PrefabList plist;

    // Use this for initialization
    void Start () {
        son_sqr = smallObjNum * smallObjNum;
        count = 0;
        prev_count = 0;
        SmallOne = new GameObject[son_sqr];
        prev_qt = Quaternion.identity;

        prefablist = GameObject.Find("PrefabList");
        plist = prefablist.GetComponent<PrefabList>();
        objsLen = plist.getObjsLen();

        First();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void First()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

        //BigOne = Instantiate(plist.getObj(0), zero, Quaternion.identity) as GameObject;
        BigOne = Instantiate(plist.getObj(0)) as GameObject;
        BigOne.name = "BigOne";

        int c = getCount(true);
        for (int i = 0; i < son_sqr; i++)
        {
            //SmallOne[i] = Instantiate(plist.getObj(c), zero, Quaternion.identity) as GameObject;
            SmallOne[i] = Instantiate(plist.getObj(c)) as GameObject;
            SmallOne[i].name = "SmallOne" + i;
        }
        
        
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    public void InitNew()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

        Destroy(BigOne);
        //BigOne = Instantiate(plist.getObj(getPrevCount()), zero, Quaternion.identity) as GameObject;
        BigOne = Instantiate(plist.getObj(getPrevCount())) as GameObject;
        BigOne.name = "BigOne";

        foreach(Transform child in SmallOne[0].transform)
        {
            prev_qt = child.transform.rotation;
            break;
        }

        int c = getCount(true);
        for(int i = 0; i < son_sqr; i++)
        {
            Destroy(SmallOne[i]);
            //SmallOne[i] = Instantiate(plist.getObj(c), zero, Quaternion.identity) as GameObject;
            SmallOne[i] = Instantiate(plist.getObj(c)) as GameObject;
            SmallOne[i].name = "SmallOne" + i;
        }
        
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
            child.transform.localPosition = new Vector3(0.0f, 0.0f, 500.0f);
            child.transform.localRotation = prev_qt;
        }
    }

    void initializeSmallOne(GameObject[] obj)
    {
        //Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject obj = GameObject.Find("SmallOne");
        //GameObject obj2 = Instantiate(obj, zero, Quaternion.identity) as GameObject;
        int i, j, k;
        int c = 0;
        float interval = (obj[0].GetComponent<PublicProp>()).interval;
        k = (int)(smallObjNum / 2 + 0.5);
        
        foreach (GameObject obj2 in obj)
        {
            i = c / smallObjNum - k;
            j = c % smallObjNum - k;
            c++;
            foreach (Transform child in obj2.transform)
            {
                child.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                child.transform.localPosition = new Vector3(interval * j, interval * i, 50.0f);
            }
        }
    }

    int getCount(bool prev_change)
    {
#if (SEQUENCE_MODE)
        count = count + 1;
#else
        count = (int)(Random.Range(0, (float)objsLen - (float)0.1));
#endif
        if (prev_change)
            prev_count = count;
        return count;
    }
    int getPrevCount()
    {
        return prev_count;
    }
    public int getSon()
    {
        return son_sqr;
    }

}
