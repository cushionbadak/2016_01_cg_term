using UnityEngine;
using System.Collections;

public class PrefabList : MonoBehaviour {

    public Object[] objs;
    private int objsLen;
    
	void Start () {
        objs = Resources.LoadAll("prefabs") as Object[];
        objsLen = objs.Length;
	}
	
	void Update () {
	
	}

    public Object getObj(int i)
    {
        return objs[i % objsLen];
    }

}
