using UnityEngine;
using System.Collections;

public class PlayerInputListener : MonoBehaviour
{
	//the current state of the player.
	private PlayerInputController.PlayerState currentPlayerState;

	public float carSpeed = 5f;

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

	void ChangeCurrentState(PlayerInputController.PlayerState newState){
		currentPlayerState = newState;
	}

	//Perform necessary steps for each state that the player is in.
	void HandleState(){

		switch (currentPlayerState) {

		case PlayerInputController.PlayerState.IDLE:

			break;
		case PlayerInputController.PlayerState.MOVE_LEFT:
			
			MoveLeft ();

			break;
		case PlayerInputController.PlayerState.MOVE_RIGHT:

			MoveRight ();

			break;
		case PlayerInputController.PlayerState.CRASHED:
			//reset the position of the car.
			transform.position = Vector3.zero;

			break;
		}

	}

	//move the player to the left.
	void MoveLeft(){

		Vector3 pos = transform.position;
		pos.x += carSpeed * Time.deltaTime;
		transform.position = pos;

	}


	//move the player to the right.
	void MoveRight(){

		Vector3 pos = transform.position;
		pos.x += carSpeed * Time.deltaTime;
		transform.position = pos;
	}

	void OnPlayerStateChanged(PlayerInputController.PlayerState newState){

		//if the current state and new state is the same, then do not handle anything.
		if(currentPlayerState == newState){
			return;
		}

		//if the player cannot go from the current state to the new state then return.
		if (!CheckForValidStateTransition (newState)) {
			return;
		}

		//make any changes related to a particular state.
		PlayerWillChangeState(newState);

		ChangeCurrentState(newState);
		
	}

	//check if the player can transition to the new state from the current state.
	//Currently the player can go from one state to another. Might need this function when more states are added.
	bool CheckForValidStateTransition(PlayerInputController.PlayerState newState){

		bool returnValue = true;

		switch (currentPlayerState) {

		case PlayerInputController.PlayerState.IDLE:

			break;

		case PlayerInputController.PlayerState.MOVE_LEFT:

			break;

		case PlayerInputController.PlayerState.MOVE_RIGHT:

			break;
		case PlayerInputController.PlayerState.CRASHED:

			break;

		}

		return returnValue;

	}

	//make changes that are related to any state. 
	void PlayerWillChangeState(PlayerInputController.PlayerState newState){
	
	
		switch (newState) {

		case PlayerInputController.PlayerState.IDLE:
			break;

		case PlayerInputController.PlayerState.MOVE_LEFT:

			//if car speed is not negative, then multiply it by -1;
			carSpeed = carSpeed < 0f ? carSpeed : carSpeed * -1f;

			break;

		case PlayerInputController.PlayerState.MOVE_RIGHT:

			carSpeed = carSpeed > 0f ? carSpeed : carSpeed * -1f;

			break;
		case PlayerInputController.PlayerState.CRASHED:

			break;
		}
	}


}

