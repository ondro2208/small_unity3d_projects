using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	public enum goDirection{ up, down, left, right, stay};
	public goDirection direction;
	public float speed;
	public GameObject mBullet;

    [HideInInspector]
    public float shootingTime = 1;
    public float _shootingTimer = 1;
    public Animation tankAnimation;


    Quaternion initialRot;
	// Use this for initialization
	void Start () 
	{
		initialRot = transform.rotation;
	}
	
	void Update()
	{
        GetComponent<Rigidbody>().velocity = Vector3.zero; 
			
		if (direction == goDirection.right)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 90, 0));

            GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.Impulse);
		}else if (direction == goDirection.left)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, -90, 0));


            GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.Impulse);
		}else if (direction == goDirection.up)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 0, 0));

            GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.Impulse);
		}else if (direction == goDirection.down)
		{
			transform.rotation = initialRot;
			transform.Rotate(new Vector3(0, 180, 0));

            GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.Impulse);
		}

        // SHOOT

        tankAnimation = GetComponent<Animation>();

        if (!tankAnimation.IsPlaying("shoot") && !tankAnimation.IsPlaying("idle"))// && animation["shoot"].time >= animation["shoot"].length)
		{
			tankAnimation.Play("idle");
		}

        _shootingTimer -= Time.deltaTime;
    }
	
	public void Shoot()
	{
        if (_shootingTimer <= 0 /*gun is ready*/)
        {
            _shootingTimer = shootingTime;

            Animation animation = GetComponent<Animation>();
            animation.Play("shoot");
            GameObject bullet = Instantiate(mBullet, transform.position + -transform.right * 7, this.transform.rotation) as GameObject;
            (bullet.GetComponent<Bullet>() as Bullet).owner = this.gameObject;
        }
           
	}
}
