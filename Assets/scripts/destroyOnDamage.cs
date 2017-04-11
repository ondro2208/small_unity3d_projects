using UnityEngine;
using System.Collections;

public class destroyOnDamage : MonoBehaviour {
	
	public GameObject ExplosionFX;
	
	public GUIText mText;
	public bool isGameOver = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(GameObject shooter)
	{
        bool isShooterEnemyTank = shooter.GetComponent<AiTank>() != null;
        bool isThisObjectEnemyTank = GetComponent<AiTank>() != null;

        // Enemy tanks should not damage each other
        if (isShooterEnemyTank && isThisObjectEnemyTank)
			return;
		
		if (ExplosionFX != null)
			Instantiate(ExplosionFX, transform.position, Quaternion.identity);
		
		if (isGameOver)
		{
			//mText.gameObject.active = true;
            //mText.gameObject.SetActive(true);

        }
		
		DestroyObject(this.gameObject);

        // Add score if the player successfully destroys an enemy tank.
        if (isThisObjectEnemyTank)
        {
            ScoreManager.score += 1;
        }
	}
}
