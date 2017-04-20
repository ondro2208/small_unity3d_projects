using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.unattachableScripts
{
    /// <summary>
    /// A helper class containing common code for all tanks controlled by the player.
    /// After creating this object, don't forget to initialize all KeyCode data members 
    /// manually (their names should tell you what they are supposed to do).
    /// 
    /// Like all classes uunder this directory, these cannot be attached to GameObjects.
    /// </summary>
    public class BaseInputHandler
    {
        public KeyCode RightKey;
        public KeyCode LeftKey;
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode ShootKey;

        TankController Controller;
        TankController.goDirection Direction = TankController.goDirection.stay;

        public BaseInputHandler(TankController Controller)
        {
            this.Controller = Controller;
        }

        public void Update()
        {
            if (Input.GetKey(RightKey))
            {
                Direction = TankController.goDirection.right;
            }
            else if (Input.GetKey(LeftKey))
            {
                Direction = TankController.goDirection.left;
            }
            else if (Input.GetKey(UpKey))
            {
                Direction = TankController.goDirection.up;
            }
            else if (Input.GetKey(DownKey))
            {
                Direction = TankController.goDirection.down;
            }
            else
                Direction = TankController.goDirection.stay;

            if (Input.GetKeyDown(ShootKey) /*&& !Bullet.isBulletAlive*/)
            {
                Controller.Shoot();
            }
            Controller.direction = Direction;
        }
    }
}
