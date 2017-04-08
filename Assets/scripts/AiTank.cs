using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class AiTank : MonoBehaviour {

    public GameObject target;

    [HideInInspector]
	public TankController controller;
	
	public double directionSwitcherTime = 1;
    public float shootingTime = 2;
	
	public double _directionSwitcherTimer = 1;
	public float _shootingTimer = 2;

    private int isAiStuckVar;
    private bool isAiStuck;

    public bool isClever;

    Transform player;


	
	// Use this for initialization
	void Start () 
	{
        controller = GetComponent<TankController>();
        target = GameObject.Find("Tank_prefab");
        player = GameObject.FindGameObjectWithTag("Tank_prefab").transform;

        this.isAiStuckVar = 0;
        this.isAiStuck = false;
    }
	
	// Update is called once per frame
	void Update () 
	{

        _directionSwitcherTimer -= Time.deltaTime;
		_shootingTimer -= Time.deltaTime;
		
		if (_directionSwitcherTimer <= 0)
		{
			_directionSwitcherTimer = directionSwitcherTime;

            //Vector3 vec = new Vector3(player.position.x, player.position.z, player.position.y);
            //nav.SetDestination(player.position);
            findAndKill();
		}

        if (_shootingTimer <= 0 /*&& !Bullet.isBulletAlive*/)
		{
			_shootingTimer = shootingTime;
			controller.Shoot();
		}
        
	}

    private void findAndKill()
    {
        TankController.goDirection directionToGo = targetDirection(transform.position, target.transform.position); // Random.Range(0, 4);

        isAiStuckMethod();

        if (isAiStuck == true)
        {
            controller.direction = directionToGo + Random.Range(-1, 1);
        }
        else
        {
            controller.direction = directionToGo;
        }
    }

    private void isAiStuckMethod()
    {
        int distance = (int) Vector3.Distance(transform.position, target.transform.position);
        if (distance == isAiStuckVar)
        {
            isAiStuck = true;
        }

        isAiStuckVar = distance;
    }

    private TankController.goDirection targetDirection(Vector3 source, Vector3 target)
    {
        float deltaX = target.x - source.x;
        float deltaZ = target.z - source.z;
        float degrees = Mathf.Atan2(deltaZ, deltaX) * (180 / Mathf.PI); // In degrees

        if (degrees >= 45 && degrees <= 135) {
            return TankController.goDirection.right;
        }
        else if (degrees <= 45 && degrees >= -45) {
            return TankController.goDirection.down;
        }
        else if (degrees <= -45 && degrees >= -135) {
            return TankController.goDirection.left;
        }
        else {
            return TankController.goDirection.up;
        }
    }
}
