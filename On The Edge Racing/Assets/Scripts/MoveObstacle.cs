using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	private int movementSpeed = 4;

	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {

		//get the rigidbody component.
		rigidbody2D = GetComponent<Rigidbody2D> ();

	}

	void FixedUpdate(){

		//move the obstacle downwards.
		rigidbody2D.velocity = Vector2.down * movementSpeed;
	}
}
