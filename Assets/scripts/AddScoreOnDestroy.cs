using UnityEngine;
using System.Collections;

public class AddScoreOnDestroy : MonoBehaviour {
	
	public static int scrores = 0;
	
	public GUIText mText;
	// Use this for initialization
	void Start () {
        mText.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(GameObject shooter)
	{
		if ((shooter.GetComponent<AiTank>() != null) && (GetComponent<AiTank>() != null))
			return;
		
		scrores++;

        mText.text = "scores: " + scrores;
        mText.gameObject.SetActive(true);
    }
}
