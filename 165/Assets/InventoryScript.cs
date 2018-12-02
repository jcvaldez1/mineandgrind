using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {


	public Text[] Minerals;
	public Text[] Weapons;
	public Text[] Armors;
	public GameObject MineralHandler;
	public GameObject WeaponHandler;
	public GameObject ArmorHandler;
	public GameObject player;
	public GameObject Menu;
	public bool isShown;
	public Inventory inventory;
	void Start () {
		Minerals = MineralHandler.GetComponentsInChildren<Text>();
		Weapons = WeaponHandler.GetComponentsInChildren<Text>();;
		Armors = ArmorHandler.GetComponentsInChildren<Text>();;
		isShown = false;
		inventory = player.GetComponent<Inventory> ();
		int counter = 0;
		//MINERALS
		/*
		foreach (GameObject mineralGO in MineralHandler.GetComponentsInChildren<GameObject> ()) {
			Minerals [counter] = mineralGO.GetComponentInChildren<Text> ();
			Debug.Log ("howmany");
			Minerals[counter].text = "balls";
			counter = counter + 1;
		}
			
		// WEAPONS
		counter = 0;
		foreach (GameObject weaponGO in WeaponHandler.GetComponentsInChildren<GameObject> ()) {
			Weapons [counter] = weaponGO.GetComponentInChildren<Text> ();
			counter = counter + 1;
		}


		// ARMORS
		counter = 0;
		foreach (GameObject armorGO in ArmorHandler.GetComponentsInChildren<GameObject> ()) {
			Armors [counter] = armorGO.GetComponentInChildren<Text> ();
			counter = counter + 1;
		}
			

		/*
		//Minerals =;
		Weapons = WeaponHandler.GetComponentsInChildren<GameObject> ();
		Armors = ArmorHandler.GetComponentsInChildren<GameObject> ();

		counter = 0;
		foreach (Armor armor in inventory.armors){
			Armors[counter].text = "Damage Reduction : " + armor.damage_reduction.ToString();
			counter = counter + 1;
		}
		counter = 0;
		foreach (Weapon weapon in inventory.weapons){
			Weapons[counter].text = "Damage : " + weapon.damage.ToString() + "\n" + 
				"Durability : " + weapon.durability;
			counter = counter + 1;
		}
		counter = 0;
		foreach (Mineral mineral in inventory.Ownedminerals){
			Minerals[counter].text = "name : " + mineral.name + "\n" +
				"rarity : " + mineral.rarity.ToString();
			counter = counter + 1;
		}
		*/
	}


	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isShown = !isShown;
			StringUpdate ();
			Menu.SetActive (isShown);
		}
	}

	public void StringUpdate(){
		int counter = 0;
		foreach (Armor armor in inventory.armors){
			if (armor != null) {
				Armors [counter].text = "Damage Reduction : " + armor.damage_reduction + "\n";

			} 
			counter = counter + 1;
		}
		for (int i = 0; i < 4 - counter; i++) {
			Armors [counter + i].text = "NONE";
		}
		counter = 0;
		foreach (Mineral mineral in inventory.Ownedminerals){
			if (mineral != null) {
				Minerals [counter].text = "name : " + mineral.name + "\n" +
					"rarity : " + mineral.rarity.ToString ();

			} else {
				Minerals [counter].text = "NONE";
			}
			counter = counter + 1;
		}
		for (int i = 0; i < 4 - counter; i++) {
			Minerals [counter + i].text = "NONE";
		}
		counter = 0;
		foreach (Weapon weapon in inventory.weapons){
			if (weapon != null) {
				Weapons[counter].text = "Damage : " + weapon.damage.ToString() + "\n" +
					"durability : " + weapon.durability.ToString();
			} else {
				Weapons[counter].text = "NONE";
			}

			counter = counter + 1;
		}
		for (int i = 0; i < 4 - counter; i++) {
			Weapons [counter + i].text = "NONE";
		}
	}

	public void EquipWeapon(string i){
		Weapon weapon = inventory.weapons [int.Parse (i)];

	}
	public void DiscardWeapon(string i){
		if (inventory.weapons[int.Parse(i)] != null) {

			UnityWebRequest uwr = UnityWebRequest.Delete(Constants.BASE_URL + "weapon/" + inventory.weapons[int.Parse(i)].id.ToString());
			uwr.SendWebRequest();
			inventory.weapons.RemoveAt( int.Parse (i));
		}

		StringUpdate ();

	}
	public void EquipArmor(string i){

	}
	public void DiscardArmor(string i){
		if (inventory.armors [int.Parse (i)] != null) {

			UnityWebRequest uwr = UnityWebRequest.Delete(Constants.BASE_URL + "armor/" + inventory.armors[int.Parse(i)].id.ToString());
			uwr.SendWebRequest();
			inventory.armors.RemoveAt( int.Parse (i));
		}
		StringUpdate ();

	}
	public void MakeWeapon(string i){
		Weapon newWeapon = new Weapon ();
		newWeapon.damage = 10;
		newWeapon.durability = 100;
		newWeapon.person_id = Constants.PERSON_ID;
		newWeapon.id = 0;
		newWeapon.mineral_type = inventory.Ownedminerals [int.Parse (i)].mineral_class;
		string theURL = Constants.BASE_URL + "weapon/";
		StartCoroutine (PostRequest(theURL,JsonUtility.ToJson(newWeapon)));
		inventory.AddWeapon (newWeapon);
		StringUpdate ();
	}
	public void MakeArmor(string i){

		Armor newArmor = new Armor ();
		newArmor.damage_reduction = 0.5f;
		newArmor.person_id = Constants.PERSON_ID;
		newArmor.id = 0;
		newArmor.amount_modifier = inventory.Ownedminerals [int.Parse (i)].mineral_class;
		string theURL = Constants.BASE_URL + "armor/";
		StartCoroutine (PostRequest(theURL,JsonUtility.ToJson(newArmor)));
		inventory.AddArmor (newArmor);
		StringUpdate ();
	}
	public void DiscardMineral(string i){
		if (inventory.Ownedminerals [int.Parse (i)] != null) {

			UnityWebRequest uwr = UnityWebRequest.Delete(Constants.BASE_URL + "mineral/" + inventory.Ownedminerals[int.Parse(i)].id.ToString());
			uwr.SendWebRequest();
			inventory.Ownedminerals.RemoveAt( int.Parse (i));
		}
		StringUpdate ();
	}

	IEnumerator PostRequest(string url, string json)
	{
		var uwr = new UnityWebRequest(url, "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
		uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
		uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		uwr.SetRequestHeader("Content-Type", "application/json");

		//Send the request then wait here until it returns
		yield return uwr.SendWebRequest();

		if (uwr.isNetworkError)
		{
			Debug.Log("Error While Sending: " + uwr.error);
		}
		else
		{
			Debug.Log("Received: " + uwr.downloadHandler.text);
		}
	}


}
