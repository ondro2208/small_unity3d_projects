using UnityEngine;
using System.Collections;

public class InputHandler2 : MonoBehaviour
{

    TankController controller;
    TankController.goDirection direction = TankController.goDirection.stay;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            direction = TankController.goDirection.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = TankController.goDirection.left;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            direction = TankController.goDirection.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = TankController.goDirection.down;
        }
        else
            direction = TankController.goDirection.stay;

        if (Input.GetKeyDown(KeyCode.Space) /*&& !Bullet.isBulletAlive*/)
        {
            controller.Shoot();
        }

        controller.direction = direction;
    }
}
