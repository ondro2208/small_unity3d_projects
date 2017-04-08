using UnityEngine;
using System.Collections;

public class directionSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		AiTank ai = transform.parent.GetComponent<AiTank>();
		if (ai)
		{
            if (ai.controller)
            {
                if (!ai.isClever)
                
                    ai.controller.direction = (TankController.goDirection)Random.Range(0, 4);
            }
		}
	}
}
