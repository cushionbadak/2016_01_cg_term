using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Text sc;
    GameManager gm;
    private int score;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sc = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        sc.text = ("EYE-CONTACT!\nScore : " + score);
	}

    public void updateScore()
    {
        score = gm.getScore();
    }
}
