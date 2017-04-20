using UnityEngine;
using System.Collections;
using Assets.scripts.unattachableScripts;

/// <summary>
/// Attach this to any player tank controllable 
/// using the standerd arrow keys (the Space key
/// is for shooting).
/// </summary>
public class InputHandlerArrows : MonoBehaviour {
	
    public BaseInputHandler Handler;
	
    // Use this for initialization
	void Start ()
    {
		Handler = new BaseInputHandler(GetComponent<TankController>());
        Handler.RightKey = KeyCode.RightArrow;
        Handler.LeftKey = KeyCode.LeftArrow;
        Handler.UpKey = KeyCode.UpArrow;
        Handler.DownKey = KeyCode.DownArrow;
        Handler.ShootKey = KeyCode.L;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Handler.Update();
	}
}
