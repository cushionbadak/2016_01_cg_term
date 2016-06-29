//#define SEQUENCE_MODE

using UnityEngine;
using System.Collections;
using System;

public class ObjectInit : MonoBehaviour
{
    public GameObject[] BigOne, SmallOne;
    public int smallObjNum;
    private int son_sqr;
    private int objsLen;
    private Quaternion prev_qt;
    private int cur_index;

    GameObject prefablist;
    PrefabList plist;

    void Start()
    {
        son_sqr = smallObjNum * smallObjNum;
        prefablist = GameObject.Find("PrefabList");
        plist = prefablist.GetComponent<PrefabList>();
        objsLen = plist.getObjsLen();
        prev_qt = Quaternion.identity;
        cur_index = 1;

        BigOne = new GameObject[objsLen];
        SmallOne = new GameObject[objsLen * son_sqr];

        First();
    }
    void Update()
    {

    }
    void First()
    {
        UnityEngine.Object temp;
        int tt;
        for (int i = 0; i < objsLen; i++)
        {
            temp = plist.getObj(i);
            BigOne[i] = Instantiate(temp) as GameObject;
            BigOne[i].name = "BigOne" + i;
            BigOne[i].SetActive(false);
            for (int j = 0; j < son_sqr; j++)
            {
                tt = son_sqr * i + j;
                SmallOne[tt] = Instantiate(temp) as GameObject;
                SmallOne[tt].name = "SmallOne" + tt;
                SmallOne[tt].SetActive(false);
            }
        }

        InitializeBigOne(BigOne, getPrevIndex());
        InitializeSmallOne(SmallOne, cur_index);
        
        BigOne[getPrevIndex()].SetActive(true);
        tt = cur_index * son_sqr;
        for(int i = 0; i < son_sqr; i++)
        {
            SmallOne[i + tt].SetActive(true);
        }
    }
    void InitializeBigOne(GameObject[] obj, int index)
    {
        foreach(Transform child in obj[index].transform)
        {
            child.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            child.transform.position = new Vector3(0.0f, 0.0f, 500.0f);
            child.transform.localRotation = prev_qt;
        }
    }
    void InitializeSmallOne(GameObject[] obj, int index)
    {
        int i, j;
        float r = UnityEngine.Random.Range(0.0f, 360.0f); // random rotation offset
        int tt = index * son_sqr; // index start point
        float interval = (obj[tt].GetComponent<PublicProp>()).interval;
        int k = (int)(smallObjNum / 2 + 0.5);
        for (int c = 0; c < son_sqr; c++)
        {
            i = c / smallObjNum - k;
            j = c % smallObjNum - k;
            foreach (Transform child in obj[tt + c].transform)
            {
                child.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                child.transform.position = new Vector3(interval * j, interval * i, 50.0f);
                child.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, r, 0.0f));
            }
        }
    }
    public void InitNew()
    {
        int tt = cur_index * son_sqr;
        // Off current objects
        BigOne[getPrevIndex()].SetActive(false);
        for(int i = 0; i < son_sqr; i++)
        {
            SmallOne[tt + i].SetActive(false);
        }

        // set prev_qt and cur_index
        foreach (Transform child in SmallOne[tt].transform)
        {
            prev_qt = child.rotation;
            break;
        }
        if (cur_index < objsLen - 1) cur_index++;
        else cur_index = 0;

        // Initialize new ones
        InitializeBigOne(BigOne, getPrevIndex());
        InitializeSmallOne(SmallOne, cur_index);

        BigOne[getPrevIndex()].SetActive(true);
        tt = cur_index * son_sqr;
        for (int i = 0; i < son_sqr; i++)
        {
            SmallOne[i + tt].SetActive(true);
        }

    }
    public int getCurIndex()
    {
        return cur_index;
    }
    public int getPrevIndex()
    {
        int a = cur_index % objsLen - 1;
        if (a < 0) return a + objsLen;
        else return a;
    }
    public int getSon()
    {
        return son_sqr;
    }
}

/*
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
            child.transform.position = new Vector3(0.0f, 0.0f, 500.0f);
            child.transform.localRotation = prev_qt;
        }
    }

    void initializeSmallOne(GameObject[] obj)
    {
        //Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject obj = GameObject.Find("SmallOne");
        //GameObject obj2 = Instantiate(obj, zero, Quaternion.identity) as GameObject;
        int i, j, k;
        float r;
        int c = 0;
        float interval = (obj[0].GetComponent<PublicProp>()).interval;
        k = (int)(smallObjNum / 2 + 0.5);
        r = UnityEngine.Random.Range(0.0f, 360.0f);

        foreach (GameObject obj2 in obj)
        {
            i = c / smallObjNum - k;
            j = c % smallObjNum - k;
            c++;
            foreach (Transform child in obj2.transform)
            {
                child.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                child.transform.position = new Vector3(interval * j, interval * i, 50.0f);
                child.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, r, 0.0f));
            }
        }
    }

    int getCount(bool prev_change)
    {
#if (SEQUENCE_MODE)
        count = count + 1;
#else
        count = (int)(UnityEngine.Random.Range(0, (float)objsLen - (float)0.1));
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
*/