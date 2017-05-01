using System.Collections;
using System.Collections.Generic;
using Assets.scripts.unattachableScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to any game object guaranteed to be active during the entire duration of a scene 
/// (current convention: attach it to the main camera of the scene) to check the current game state 
/// and display a message about it to the player(s) if necessary.
/// </summary>
public class GameStateChecker : MonoBehaviour {

    IGameStateEvaluator Tester;
    GUIText Text;
    GameState CurrentState;
    int NumLevels;
	string StartMenuString = "StartMenu";

	// Use this for initialization
	void Start () {
        this.CurrentState = GameState.PLAYING;
        this.Tester = new StandardStateEvaluator();
        this.Text = GameObject.FindWithTag("MainText").GetComponent<GUIText>();
        // One of the scenes is the main menu, do not count that scene as a level.
        this.NumLevels = SceneManager.sceneCountInBuildSettings - 1;
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
                    StartCoroutine(LoadMainMenuAfterLosing(3));
                    break;
                case GameState.WON:
                    RenderMainText("Congratulations!");
					StartCoroutine(LoadLevelAfterDelay(5)); 
                    break;
            }
        }
	}

	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (CurrentSceneIndex < NumLevels)
        {
            // start next level
            SceneManager.LoadScene(CurrentSceneIndex + 1);
        }
        else
        {
            // return to main menu after completing final level
            SceneManager.LoadScene(StartMenuString);
        }
    }

    IEnumerator LoadMainMenuAfterLosing(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(StartMenuString);
    }

    void RenderMainText(string message)
    {
        Text.text = message;
        Text.gameObject.SetActive(true);
    }
}
