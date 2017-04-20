using System.Collections;
using System.Collections.Generic;
using Assets.scripts.unattachableScripts;
using UnityEngine;

/// <summary>
/// Attach this to the players' base object to check the current state of the game 
/// and display a message about the current state if necessary.
/// </summary>
public class GameStateChecker : MonoBehaviour {

    IGameStateEvaluator Tester;
    GUIText Text;
    GameState CurrentState;

	// Use this for initialization
	void Start () {
        this.CurrentState = GameState.PLAYING;
        this.Tester = new StandardStateEvaluator();
        this.Text = GameObject.FindWithTag("MainText").GetComponent<GUIText>();
    }
	
	// Update is called once per frame
	void Update () {
        if (CurrentState == GameState.PLAYING) {
            CurrentState = Tester.TestGameState(CurrentState);
            switch (CurrentState) {
                case GameState.PLAYING:
                    break;
                case GameState.LOST:
                    RenderMainText("Game over!");
                    break;
                case GameState.WON:
                    RenderMainText("Congratulations!");
                    break;
            }
        }
	}

    void OnDestroy() {
        CurrentState = GameState.LOST;
        RenderMainText("Game over!");
    }

    void RenderMainText(string message) {
        Text.text = message;
        Text.gameObject.SetActive(true);
    }
}
