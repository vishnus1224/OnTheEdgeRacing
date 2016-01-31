﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//represents the various states that the game can be in.
	public enum GameState{
		NOT_STARTED, RUNNING, PAUSED, GAME_OVER
	}

	public delegate void GameStateChanged (GameState gameState);

	public static event GameStateChanged onGameStateChanged;

	void OnEnable(){

		//listen to player collision event.
		PlayerCollisionDetector.OnPlayerCollided += OnPlayerCrash;
	}

	void OnDisable(){

		PlayerCollisionDetector.OnPlayerCollided -= OnPlayerCrash;
	}


	// Use this for initialization
	void Start () {

		//if running on android then start game in 2 seconds.
		#if UNITY_ANDROID
		Invoke("StartGame", 2f);
		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Return)) {

			StartGame ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
		
			PauseGame ();
		}
	}

	void StartGame(){

		//send an event that the game has started.
		if (onGameStateChanged != null) {
			
			onGameStateChanged (GameState.RUNNING);
		}

	}

	void PauseGame(){

		if (onGameStateChanged != null) {
		
			onGameStateChanged (GameState.PAUSED);
		}

	}


	void OnPlayerCrash(){

		//signal to the listeners that player has crashed and the game has ended.
		if (onGameStateChanged != null) {
			
			onGameStateChanged (GameState.GAME_OVER);

		}

		Invoke("StartGame", 2f);
		Invoke ("ResetPosition", 1f);
	}

	void ResetPosition(){
		
		if (onGameStateChanged != null) {

			onGameStateChanged (GameState.NOT_STARTED);

		}

	}

}
