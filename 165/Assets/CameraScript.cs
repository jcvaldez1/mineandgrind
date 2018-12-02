using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	public GameObject playerObject;
	public Transform player;
	public Vector3 offset;
	public float smoothSpeed = 10.0f;

	void Start () {
		offset = new Vector3 (0,0,-10);
		player = playerObject.GetComponent<Transform> ();
	}

	void LateUpdate () 
	{
		Vector3 desiredPosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (player.position, desiredPosition,smoothSpeed*Time.deltaTime);
		transform.position = smoothedPosition; // Camera follows the player with specified offset position
	}


}
