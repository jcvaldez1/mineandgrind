using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralPrefabScript : MonoBehaviour {

	public GameObject thePlayer;
	private bool playerInteract;
	public Mineral mineral;
	void Start () {
		playerInteract = false;
		thePlayer = GameObject.Find ("Player");
		//Debug.Log (initManager);
	}

	public void Setup(Mineral instance) {
		//Debug.Log (instance.person_id);
		this.mineral = instance;
	}

	void Update () {
		if (playerInteract) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				// JSON PATCH MINERAL ID TO SERVER

				// ADD THIS SHIT TO INVENTORY
				//gameObject.GetComponent<Inventory>().AddMineral(this.mineral);
				thePlayer.GetComponent<Inventory>().AddMineral(this.mineral);
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collision){
		if (collision.gameObject.CompareTag ("Player")) {
			playerInteract = true;
		}

	}
	void OnTriggerExit2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("Player")) {
			playerInteract = false;
		}
	}
}
