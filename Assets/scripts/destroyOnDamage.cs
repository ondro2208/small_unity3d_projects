using UnityEngine;
using System.Collections;

public class destroyOnDamage : MonoBehaviour {
	
    // Must be instantiated in the editor with a prefab representing an explosion
	public GameObject ExplosionFX;
	
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
        {
            return;
        }
        else if (isThisObjectEnemyTank)
        {
            // Add score if the player successfully destroys an enemy tank.
            shooter.GetComponent<ScoreManager>().UpdateScore(1);
        }

        if (ExplosionFX != null)
			Instantiate(ExplosionFX, transform.position, Quaternion.identity);

        DestroyObject(this.gameObject);
	}
}
