using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IF EXTENDING MIGHT BE GOOD TO MAKE SEPARATE C# FILES FOR EACH OF THE CLASS DECLARATIONS
// ALSO MAKE A PARENT ABSTRACT CLASS/INTERFACE THAT THESE CLASSES SHOULD EXTEND

abstract public class GameElement {
	void test (){
	}
}

[System.Serializable]
public class Person {
	public int id;
	public string name;
	public int level;
	public int health;
}
	
[System.Serializable]
public class Weapon{
	public int id;
	public int damage;
	public int durability;
	public int person_id;
	public int mineral_type;
}
	
[System.Serializable]
public class EnemyType {
	public string the_class;
}

[System.Serializable]
public class MineralType {
	public string the_class;
}

[System.Serializable]
public class Equip {
	public int person_id;
	public int gear;
}

[System.Serializable]
public class Paired {
	public int armor_id;
	public int weapon_id;
}


