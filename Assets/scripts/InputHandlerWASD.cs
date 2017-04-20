using UnityEngine;
using System.Collections;
using Assets.scripts.unattachableScripts;

/// <summary>
/// Attach this to any player tank controllable 
/// using the standerd arrow keys (the L key is 
/// for shooting).
/// </summary>
public class InputHandlerWASD : MonoBehaviour
{

    private BaseInputHandler Handler;

    // Use this for initialization
    void Start()
    {
        Handler = new BaseInputHandler(GetComponent<TankController>());
        Handler.RightKey = KeyCode.D;
        Handler.LeftKey = KeyCode.A;
        Handler.UpKey = KeyCode.W;
        Handler.DownKey = KeyCode.S;
        Handler.ShootKey = KeyCode.Space;
    }

    // Update is called once per frame
    void Update()
    {
        Handler.Update();
    }
}
