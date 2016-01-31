using UnityEngine;
using System.Collections;

public class RoadScroller : MonoBehaviour {

	public float speed = 2f;

	private Renderer meshRenderer;

	// Use this for initialization
	void Start () {
	
		meshRenderer = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		meshRenderer.material.mainTextureOffset = new Vector2 (0, Time.time * speed);

	}
}
