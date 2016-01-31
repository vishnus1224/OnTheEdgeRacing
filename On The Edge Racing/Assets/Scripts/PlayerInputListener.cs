using UnityEngine;
using System.Collections;

public class PlayerInputListener : MonoBehaviour
{
	//the current state of the player.
	private PlayerInputController.PlayerState currentPlayerState;

	void OnEnable(){

		//subscribe to the player state changed event from the player input controller.
		PlayerInputController.OnPlayerStateChanged += OnPlayerStateChanged;
	}

	void OnDisable(){
	
		//unsubscribe when the script is disabled.
		PlayerInputController.OnPlayerStateChanged -= OnPlayerStateChanged;
	}

	// Use this for initialization
	void Start ()
	{
	
		//set the initial state of the player to idle.
		currentPlayerState = PlayerInputController.PlayerState.IDLE;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void LateUpdate(){

		HandleState ();

	}

	//Perform necessary steps for each state that the player is in.
	void HandleState(){

		switch (currentPlayerState) {

		case PlayerInputController.PlayerState.IDLE:

			break;
		case PlayerInputController.PlayerState.MOVE_LEFT:
			Debug.Log ("Moving Left");
			break;
		case PlayerInputController.PlayerState.MOVE_RIGHT:
			Debug.Log ("Moving Right");
			break;
		}

	}

	void OnPlayerStateChanged(PlayerInputController.PlayerState newState){

		//if the current state and new state is the same, then do not handle anything.
		if(currentPlayerState == newState){
			return;
		}

		//if the player cannot go from the current state to the new state then return.
		if (!checkForValidStateTransition (newState)) {
			return;
		}

		currentPlayerState = newState;
		
	}

	//check if the player can transition to the new state from the current state.
	//Currently the player can go from one state to another. Might need this function when more states are added.
	bool checkForValidStateTransition(PlayerInputController.PlayerState newState){

		bool returnValue = true;

		switch (currentPlayerState) {

		case PlayerInputController.PlayerState.IDLE:

			break;

		case PlayerInputController.PlayerState.MOVE_LEFT:

			break;

		case PlayerInputController.PlayerState.MOVE_RIGHT:

			break;

		}

		return returnValue;

	}


}

