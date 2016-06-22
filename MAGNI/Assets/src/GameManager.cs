using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    static public bool[] scoreQueue;
    static private int size;
    static private int queuePoint;

	// Use this for initialization
	void Start () {
        size = 20;
        scoreQueue = new bool[size];
        for(int i = 0; i < size;i++)
        {
            scoreQueue[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    int getQPoint()
    {
        int i = queuePoint % size;
        queuePoint++;
        return i;
    }

    public void writeScore(bool b)
    {
        scoreQueue[getQPoint()] = b;
    }

    public int getScore()
    {
        int sum = 0;
        for(int i = 0; i < size;i++)
        {
            if (scoreQueue[i]) sum++;
        }
        return sum;
    }
}
