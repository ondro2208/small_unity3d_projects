using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int Score = 0;
    public GUIText Text;

	// Use this for initialization
	void Start () {
        Text.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateScore(int ScoreDelta) {
        Score += ScoreDelta;
        Text.text = "Score: " + Score;
    }
}
