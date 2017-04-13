using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class AiTank : MonoBehaviour {

    public GameObject target;

    public bool isAiStuck;

    [HideInInspector]
	public TankController controller;
	
	public double directionSwitcherTime = 1;
    public float shootingTime = 2;
	
	public double _directionSwitcherTimer = 1;
	public float _shootingTimer = 2;

    public bool isClever;
   
    



    // Use this for initialization
    void Start () 
	{
        controller = GetComponent<TankController>();
        target = GameObject.Find("Tank_prefab");
        isAiStuck = false;
        isClever = true;
    }
	
	// Update is called once per frame
	void Update () 
	{

        _directionSwitcherTimer -= Time.deltaTime;
		_shootingTimer -= Time.deltaTime;
		
		if (_directionSwitcherTimer <= 0)
		{
			_directionSwitcherTimer = 2;

            isAiStuck = isEnemyStuck();

            //Vector3 vec = new Vector3(player.position.x, player.position.z, player.position.y);
            //nav.SetDestination(player.position);

            if (Random.Range(0, 2) == 1)
            {
                if(Random.Range(0, 2) == 1)
                    target = GameObject.Find("Tank_prefab");
                else
                    target = GameObject.Find("Tank_prefab (1)");
            }
            else
            {
                target = GameObject.Find("Base_prefab");
            }


            target = GameObject.Find("Base_prefab");

            findAndKill();

		}

        if (_shootingTimer <= 0 /*&& !Bullet.isBulletAlive*/)
		{
			_shootingTimer = 2 + Random.Range(-1, 1);
			controller.Shoot();
		}
        
	}
    
    // do not call in each frame
    private bool isEnemyStuck()
    {
        if ( (int) lastKnownDegree == (int) degrees)
        {
            lastKnownDegree = degrees;
            return true;
        }
        else
        {
            lastKnownDegree = degrees;
            return false;
        }
    }

    private void findAndKill()
    {
        int directionToGo = targetDirection(transform.position, target.transform.position); // Random.Range(0, 4);

        if (isAiStuck == true)
        {
            int randomNum = Random.Range(0, 2); // to decide to go right or left when collision occurs

            if (directionToGo == 0 || directionToGo == 1)
                if (randomNum == 1)
                    directionToGo = 3;
                else
                    directionToGo = 2;

            if (directionToGo == 2 || directionToGo == 3)
                if (randomNum == 1)
                    directionToGo = 1;
                else
                    directionToGo = 0;
        }

            controller.direction = (TankController.goDirection) directionToGo;
    }

    private float lastKnownDegree;
    public float degrees;

    private int targetDirection(Vector3 source, Vector3 target)
    {
        float deltaX = target.x - source.x;
        float deltaZ = target.z - source.z;
        degrees = Mathf.Atan2(deltaZ, deltaX) * (180 / Mathf.PI); // In degrees

        if (degrees >= 45 && degrees <= 135) {
            return 3; // right
        }
        else if (degrees <= 45 && degrees >= -45) {
            return 1; // down
        }
        else if (degrees <= -45 && degrees >= -135) {
            return 2; // left
        }
        else {
            return 0; // up
        }
    }
}
