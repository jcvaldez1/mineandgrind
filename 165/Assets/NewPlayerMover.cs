using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMover : MonoBehaviour {


	//private Constants constants = GameObject.Find("SceneManager").GetComponent<Constants>();
	private Vector3 pos;
	private Transform tr;
	private float moveSpeedBonus;
	private bool isBlocked;
	private Vector3 currentOrientation;
	void Start () {
		pos = transform.position;
		tr = transform;
		isBlocked = false;
		currentOrientation = new Vector3(0,0,0);
	}
	
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		if (Input.GetKey (KeyCode.D) && tr.position == pos) {
			currentOrientation = new Vector3 (0, 0, -90);
			transform.eulerAngles = currentOrientation;
			if (!isBlocked) {
				pos += (Vector3.right * Constants.PLAYER_MOVEMENT_SCALE);	
			}
		}
		else if (Input.GetKey(KeyCode.A) && tr.position == pos) {
			currentOrientation = new Vector3(0,0,90);
			transform.eulerAngles = currentOrientation;
			if (!isBlocked) {
				pos += (Vector3.left*Constants.PLAYER_MOVEMENT_SCALE);
			}
		}
		else if (Input.GetKey(KeyCode.W) && tr.position == pos) {
			currentOrientation = new Vector3(0,0,0);
			transform.eulerAngles = currentOrientation;
			if (!isBlocked) {
				pos += (Vector3.up*Constants.PLAYER_MOVEMENT_SCALE);
			}
		}
		else if (Input.GetKey(KeyCode.S) && tr.position == pos) {
			currentOrientation = new Vector3(0,0,180);
			transform.eulerAngles = currentOrientation;
			if (!isBlocked) {
				pos += (Vector3.down*Constants.PLAYER_MOVEMENT_SCALE);
			}
		}

		moveSpeedBonus = 1.0f;
		if (Input.GetKey (KeyCode.LeftShift)) {
			moveSpeedBonus = Constants.RUNNING_SPEED_BONUS;
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 2.0f * moveSpeedBonus);
		//StartCoroutine (MoveAndWait());
		//Vector3 movement = new Vector3 (horizontal, vertical, 0f);
		//transform.position += movement * Time.deltaTime;
	}



	IEnumerator MoveAndWait(){
		yield return new WaitForSeconds (Constants.playerMovementDelay);
	}

	void OnTriggerEnter2D(Collider2D other){
		isBlocked = true;
	}
	void OnTriggerExit2D(Collider2D other){
		isBlocked = false;
	}

}
