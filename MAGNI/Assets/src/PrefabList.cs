using UnityEngine;
using System.Collections;

public class PrefabList : MonoBehaviour {

    public Object[] objs;
    private int objsLen;
    
	void Awake () {
        objs = Resources.LoadAll("prefabs") as Object[];
        objsLen = objs.Length;
	}

    void Start()
    {

    }
	
	void Update () {
	
	}

    public Object getObj(int i)
    {
        int n;
        if (objsLen <= i)
            n = i % objsLen;
        else
            n = i;
        return objs[n];
    }

}
