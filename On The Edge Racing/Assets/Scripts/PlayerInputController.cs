using UnityEngine;
using System.Collections;

/**
 * Handles the input for moving the player.
 * */
public class PlayerInputController : MonoBehaviour {

	public enum PlayerState{
		IDLE, MOVE_LEFT, MOVE_RIGHT, CRASHED
	}

	private GameManager.GameState currentGameState = GameManager.GameState.NOT_STARTED;

	public delegate void PlayerStateChanged(PlayerState playerState);

	public static event PlayerStateChanged OnPlayerStateChanged;

	private const float MIN_ACCELERATION = 0.1f;

	void OnEnable(){

		GameManager.onGameStateChanged += GameStateChanged;

	}

	void OnDisable(){
		
		GameManager.onGameStateChanged -= GameStateChanged;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){

		HandleGameState ();
	}

	void HandleGameState(){

		switch (currentGameState) {

		case GameManager.GameState.NOT_STARTED:


			break;

		case GameManager.GameState.RUNNING:

			//process input from the user if the game is running.
			ProcessInput ();

			break;

		case GameManager.GameState.PAUSED:

			if (OnPlayerStateChanged != null) {

				OnPlayerStateChanged (PlayerState.IDLE);
			}

			break;

		case GameManager.GameState.GAME_OVER:

			if (OnPlayerStateChanged != null) {

				OnPlayerStateChanged (PlayerState.CRASHED);
			}

			break;

		}

	}

	void GameStateChanged(GameManager.GameState newState){

		if (currentGameState == newState) {
			return;
		}
	
		currentGameState = newState;
	}

	void ProcessInput(){

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.LeftArrow)){

			if (OnPlayerStateChanged != null) {

				OnPlayerStateChanged (PlayerState.MOVE_LEFT);
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)) {

			if (OnPlayerStateChanged != null) {

				OnPlayerStateChanged (PlayerState.MOVE_RIGHT);
			}

		}

		#endif

		//if running on android process accelerometer input
		#if UNITY_ANDROID

		//get the value of acceleration on the x axis.
		float xAcceleration = Input.acceleration.x;

		if(xAcceleration < 0 && Mathf.Abs(xAcceleration) > MIN_ACCELERATION && OnPlayerStateChanged != null){

			OnPlayerStateChanged(PlayerState.MOVE_LEFT);

		}else if(xAcceleration > 0 && Mathf.Abs(xAcceleration) > MIN_ACCELERATION && OnPlayerStateChanged != null){

			OnPlayerStateChanged(PlayerState.MOVE_RIGHT);

		}else {

			if(OnPlayerStateChanged != null){

				OnPlayerStateChanged(PlayerState.IDLE);

			}

		}

		#endif
	}


}
