using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {

	public delegate void PlayerCollided ();

	public static event PlayerCollided OnPlayerCollided;

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Edge")) {

			if (OnPlayerCollided != null) {
				
				//broadcast that the player has collided.
				OnPlayerCollided ();
			}
		} else if (other.CompareTag ("Block")) {

			if (OnPlayerCollided != null) {

				//broadcast that the player has collided.
				OnPlayerCollided ();
			}
		} else if (other.CompareTag ("Score Line")) {

			Debug.Log("Scored");

		}
	}
}
