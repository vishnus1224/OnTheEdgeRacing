using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//represents the various states that the game can be in.
	public enum GameState{
		NOT_STARTED,RUNNING, PAUSED, GAME_OVER
	}

	//current state of the game.
	private GameState currentState = GameState.NOT_STARTED;

	public delegate void GameStateChanged (GameState gameState);

	public static event GameStateChanged onGameStateChanged;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Return)) {
			StartGame ();
		}
	}

	void StartGame(){

		Debug.Log ("Started");

		//change the current state of the game to running.
		currentState = GameState.RUNNING;

		//send an event that the game has started.
		if (onGameStateChanged != null) {
			onGameStateChanged (currentState);
		}

	}
}
