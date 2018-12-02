using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;


// FOR THE LOVE OF GOD MAKE THIS AN EXTENDABLE IMPLEMENTATION
public class Inventory : MonoBehaviour {
	public List<Armor> armors;
	public List<Weapon> weapons;
	public List<Mineral> minerals;
	public List<Enemy> enemies;
	public List<Mineral> Ownedminerals;
	private string baseURL = Constants.BASE_URL;
	public Weapon equippedWeapon;
	public Armor equippedArmor;
	public int userID;
	public string dataAsJson;
	public int pairID;

	public void Start(){
		userID = Constants.PERSON_ID;
		string modifiedURL = baseURL + "equip/?person_id=" + userID + "&format=json/";
		WWW request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		Equip equipped = JsonUtility.FromJson<Equip> (dataAsJson);

		pairID = equipped.gear;

		modifiedURL = baseURL + "paired/" + equipped.gear.ToString() + "/&format=json/";
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		Paired pair = JsonUtility.FromJson<Paired> (dataAsJson);

		modifiedURL = baseURL + "weapon/" + pair.weapon_id.ToString() + "/&format=json/";
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		equippedWeapon = JsonUtility.FromJson<Weapon> (dataAsJson);

		modifiedURL = baseURL + "weapon/" + pair.armor_id.ToString() + "/&format=json/";
		request = new WWW (modifiedURL);
		StartCoroutine (OnResponse (request));
		equippedArmor = JsonUtility.FromJson<Armor> (dataAsJson);
		 
	}
	public void Setup(Armor[] armors, Weapon[] weapons, Mineral[] minerals, Enemy[] enemies){
		this.armors = armors.ToList();
		this.weapons = weapons.ToList();
		this.minerals = minerals.ToList();
		this.enemies = enemies.ToList();
		this.Ownedminerals = new List<Mineral> ();
	}
	public void AddMineral(Mineral mineral){
		mineral.person_id = Constants.PERSON_ID;
		string theObject = JsonUtility.ToJson (mineral);
		//Debug.Log (theObject);
		UnityWebRequest www = UnityWebRequest.Put (baseURL + "mineral/" + mineral.id.ToString() + "/", theObject);
		www.SetRequestHeader ("Content-Type","application/json");
		www.SendWebRequest ();
		this.Ownedminerals.Add (mineral);
	}
	public void AddArmor(Armor armor){
		this.armors.Add (armor);
	}
	public void AddWeapon(Weapon weapon){
		this.weapons.Add (weapon);
	}

	private IEnumerator OnResponse(WWW req){

		int waitboy = 0;
		while (!req.isDone) {
			waitboy = 1;
		}
		if (req.isDone) {
			dataAsJson =  req.text;
		}
		yield return req;

	}


}
