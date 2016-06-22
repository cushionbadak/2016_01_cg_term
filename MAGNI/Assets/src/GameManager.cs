using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    //static public bool[] scoreQueue;
    //static private int size;
    //static private int queuePoint;
    static private int score;

	// Use this for initialization
	void Start () {
        //size = 20;
        //scoreQueue = new bool[size];
        //for(int i = 0; i < size;i++)
        //{
        //    scoreQueue[i] = false;
        //}
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {

	}

    int getQPoint()
    {
        //int i = queuePoint % size;
        //queuePoint++;
        //return i;
        return 0;
    }

    public void writeScore(bool b)
    {
        //scoreQueue[getQPoint()] = b;
        if (b)
            score++;
    }

    public int getScore()
    {
        //int sum = 0;
        //for(int i = 0; i < size;i++)
        //{
        //    if (scoreQueue[i]) sum++;
        //}
        //return sum;
        return score;
    }
}
