using UnityEngine;
using System.Collections;

/**
 * Singleton class for managing the state of the game.
 * */
public class GameManager : MonoBehaviour {

	public static GameManager sharedInstance;

	void Awake(){

		if (sharedInstance == null) {
		
			sharedInstance == this;
		
		} else if (sharedInstance != this) {
		
			Destroy (gameObject);
		}

		//Do not destroy this when loading scenes.
		DontDestroyOnLoad (gameObject);
	
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
