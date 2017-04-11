using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    GUIText text;

	// Use this for initialization
	void Start () {
        text = GetComponent <GUIText> ();
        text.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score;
	}
}
