using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

	public GameObject[] obstacles;

	private GameManager.GameState currentGameState;

	//the time that has elapsed since the last obstacle was spawned.
	private float accumulatedSpawnTime;

	private float obstacleSpawnDelay = 2f;

	void OnEnable(){

		GameManager.onGameStateChanged += GameStateChanged;
	}

	void OnDisable(){
		
		GameManager.onGameStateChanged -= GameStateChanged;

	}

	void Update(){

		HandleGameState ();

	}

	void HandleGameState(){

		//return if the game is not currently running.
		if (currentGameState != GameManager.GameState.RUNNING) {
			return;
		}

		switch (currentGameState) {

		case GameManager.GameState.NOT_STARTED:

			break;

		case GameManager.GameState.RUNNING:

			//increase the accumulated time by the delta time.
			accumulatedSpawnTime += Time.deltaTime;

			//if accumulated time is more than spawn delay, then spawn the obstacle.
			if (accumulatedSpawnTime > obstacleSpawnDelay) {

				SpawnObstacle ();

				//reset the time.
				accumulatedSpawnTime = 0f;

			}

			break;

		case GameManager.GameState.PAUSED:

			break;

		case GameManager.GameState.GAME_OVER:

			break;

		}


	}

	void GameStateChanged(GameManager.GameState newState){

		if (currentGameState == newState) {
			return;
		}
			
		currentGameState = newState;
	}

	//spawns a random obstacle.
	void SpawnObstacle(){

		GameObject obstacle = obstacles [Random.Range (0, obstacles.Length)];


		//spawn the obstacle a little above the display area and let it move into the scene.
		Instantiate (obstacle, new Vector3(0, 10, 0), Quaternion.identity);

	}
}
