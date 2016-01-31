using UnityEngine;
using System.Collections;

/**
 * Handles the input for moving the player.
 * */
public class PlayerInputController : MonoBehaviour {

	public enum PlayerState{
		IDLE, MOVE_LEFT, MOVE_RIGHT
	}

	public delegate void PlayerStateChanged(PlayerState playerState);

	public static event PlayerStateChanged OnPlayerStateChanged;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void LateUpdate(){

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
	}
}
