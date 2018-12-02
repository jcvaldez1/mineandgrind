using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonBehaviour : MonoBehaviour {

	public Person person;
	public Weapon equippedWeapon;
	public Armor equippedArmor;


	public int getDamage (){
		return equippedWeapon.damage;
	}

	public void equipWeapon(){
		// PUT  REQUEST TO EDIT CURRENTLY EQUIPPED WEAPON

	}
}
