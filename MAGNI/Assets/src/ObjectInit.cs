using UnityEngine;
using System.Collections;

public class ObjectInit : MonoBehaviour {

    //public Object bigbig, smallsmall;
    public GameObject BigOne;
    public GameObject[] SmallOne;
    public int smallObjNum;
    public int interval;
    private int son_sqr;
    private int count;
    private int prev_count;
    private int objsLen;

    GameObject prefablist;
    PrefabList plist;

    // Use this for initialization
    void Start () {
        son_sqr = smallObjNum * smallObjNum;
        count = 0;
        prev_count = 0;
        SmallOne = new GameObject[son_sqr];

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

        BigOne = Instantiate(plist.getObj(0), zero, Quaternion.identity) as GameObject;
        BigOne.name = "BigOne";

        int c = getCount(true);
        for (int i = 0; i < son_sqr; i++)
        {
            SmallOne[i] = Instantiate(plist.getObj(c), zero, Quaternion.identity) as GameObject;
            SmallOne[i].name = "SmallOne" + i;
        }
        
        
        initializeBigOne(BigOne);
        initializeSmallOne(SmallOne);
    }

    public void InitNew()
    {
        Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

        Destroy(BigOne);
        BigOne = Instantiate(plist.getObj(getPrevCount()), zero, Quaternion.identity) as GameObject;
        BigOne.name = "BigOne";

        int c = getCount(true);
        for(int i = 0; i < son_sqr; i++)
        {
            Destroy(SmallOne[i]);
            SmallOne[i] = Instantiate(plist.getObj(c), zero, Quaternion.identity) as GameObject;
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
            child.transform.localPosition = new Vector3(0.0f, 0.0f, 40.0f);
        }
    }

    void initializeSmallOne(GameObject[] obj)
    {
        //Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject obj = GameObject.Find("SmallOne");
        //GameObject obj2 = Instantiate(obj, zero, Quaternion.identity) as GameObject;
        int i, j;
        int c = 0;
        foreach (GameObject obj2 in obj)
        {
            //TODOTODOTODO
            foreach (Transform child in obj2.transform)
            {
                child.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                child.transform.localPosition = new Vector3(0.0f, 0.0f, 20.0f);
            }
        }
    }

    int getCount(bool prev_change)
    {
        count = (int)(Random.Range(0, (float)objsLen - (float)0.1));
        if (prev_change)
            prev_count = count;
        return count;
    }
    int getPrevCount()
    {
        return prev_count;
    }
}
