using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	private int movementSpeed = 4;

	void LateUpdate(){

		Vector3 position = transform.position;
		position.y -= movementSpeed * Time.deltaTime;
		transform.position = position;
	}
}
