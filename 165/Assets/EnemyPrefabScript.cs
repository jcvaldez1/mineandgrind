using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabScript : MonoBehaviour {

	public GameObject initManager;
	private bool playerInteract;
	private GameObject thePlayer;
	public Enemy enemy;
	void Start () {
		playerInteract = false;
		initManager = GameObject.Find ("Init_Manager");
	}

	public void Setup(Enemy instance) {
		this.enemy= instance;
	}

	void Update () {
		if (playerInteract) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				// JSON PATCH MINERAL ID TO SERVER

				// ADD THIS SHIT TO INVENTORY
				//gameObject.GetComponent<Inventory>().AddMineral(this.mineral);
				Fight(thePlayer,enemy);

				//initManager.GetComponent<InitScene>().attainMineral(this.mineral);
				if (this.enemy.health <= 0) {
					Destroy (gameObject);
				}

			}
		}
	}

	void Fight(GameObject thePlayer, Enemy enemy){
		// GET EQUIPPED SHIT
		PersonBehaviour player_methods = thePlayer.GetComponent<PersonBehaviour>();
		//int equipped_weapon_damage = player_methods.getDamage ();
		// LOWER HEALTHS
		// LOWER DURABILITIES
		// SEND POST REQUEST FOR NEW FIGHT EVENT
	}



	void OnTriggerStay2D (Collider2D collision){
		if (collision.gameObject.CompareTag("Player")) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				// INITIATE FIGHT SEQUENCE

			}
		}
	}
}
