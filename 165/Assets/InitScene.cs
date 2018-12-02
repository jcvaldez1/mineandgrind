using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InitScene : MonoBehaviour {


	private string dataAsJson;
	private string baseURL = Constants.BASE_URL;
	private string userID;
	private WWWForm form;
	public Inventory inventory;
	private Dictionary<string, string> headers;
	public GameObject mineralPrefab;
	public GameObject enemyPrefab;

	private Armor[] theArmors;
	private Mineral[] theMinerals;
	private Weapon[] theWeapons;
	private Enemy[] theEnemies;
	void Awake () {
		// LOAD INITIAL GAME DATA
		form  = new WWWForm ();
		headers = form.headers;
		//userID = PlayerPrefs.GetInt("userID").ToString() + "&format=json/";
		//userID = Constants.PERSON_ID.ToString()+"&/format=json";
		userID = "1&format=json";
		string[] temp;
		// EXTREMELY SHIT CODE THAT DOESNT FOLLOW SOLID AHEAD

		// RETRIEVE ALL CURRENT ARMORS.
		string modifiedURL = baseURL + "armor/?person_id=" + userID;
		WWW request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		theArmors = JsonHelper.FromJson<Armor>(dataAsJson);
		Debug.Log (theArmors.Length);



		// RETRIEVE ALL CURRENT WEAPONS
		modifiedURL = baseURL + "weapon/?person_id=" + userID;
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		theWeapons = JsonHelper.FromJson<Weapon>(dataAsJson);
		Debug.Log (theWeapons.Length);

		// RETRIEVE ALL CURRENT MINERALS
		modifiedURL = baseURL + "mineral/?world_id=" + userID;
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		theMinerals = JsonHelper.FromJson<Mineral>(dataAsJson);
		Debug.Log (theMinerals.Length);

		// RETRIEVE ALL CURRENT ENEMIES
		modifiedURL = baseURL + "enemy/?world_id=" + userID;
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		theEnemies = JsonHelper.FromJson<Enemy>(dataAsJson);
		Debug.Log (theEnemies.Length);

		// END OF EXTREMELY SHIT CODE

		// SETUP THE INVENTORY SO THAT IT CAN BE REFERENCED GLOBALLY
		//inventory = GameObject.Find ("Init_Manager").GetComponent<Inventory> ();
		inventory = GameObject.Find("Player").GetComponent<Inventory>();
		inventory.Setup (theArmors, theWeapons, theMinerals, theEnemies);

		// AGAIN MAKE THE FOLLOWING EXTENDABLE IN THE FUTURE
		initMinerals(inventory.minerals);
		initEnemies (inventory.enemies);
	}
	private IEnumerator OnResponse(WWW req){

		int waitboy = 0;
		while (!req.isDone) {
			waitboy = 1;
		}
		if (req.isDone) {
			dataAsJson =  "{\"Items\":" + req.text + "}";
			//dataAsJson =  req.text;
		}
		yield return req;

	}
	void initMinerals(List<Mineral> minerals){
		GameObject local;
		for (int i = 0; i < minerals.Count; i++) {
			if( minerals[i].person_id != null && minerals[i].person_id != 0){
				inventory.AddMineral (minerals[i]);
			}
			else {
				local = Instantiate (mineralPrefab, new Vector3(minerals[i].location_x, minerals[i].location_y,0), Quaternion.identity); // SET LOCATION HERE
				Debug.Log(minerals[i].person_id);
				local.GetComponent<MineralPrefabScript>().Setup(minerals[i]);
			}

		}
	}
	void initEnemies(List<Enemy> enemies){
		GameObject local;
		for (int i = 0; i < enemies.Count; i++) {
			local = Instantiate (enemyPrefab, new Vector3(enemies[i].location_x, enemies[i].location_y,0), Quaternion.identity); // SET LOCATION HERE
			local.GetComponent<EnemyPrefabScript>().Setup(enemies[i]);
		}
	}

	public void attainMineral(Mineral mineral){
		
		inventory.AddMineral (mineral);
	}

}