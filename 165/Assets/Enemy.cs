using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy {
	public int damage;
	public int health;
	public int enemy_class;	
	public int world_id;
	public float location_x;
	public float location_y;
	/*
	void Awake(){
		// RENDER THE SPRITE AND SET THE POSITION
	}
	public void Setup(Enemy instance){
		this.damage = instance.damage;
		this.health = instance.health;
		this.enemy_class = instance.enemy_class;
		this.location_x = instance.location_x;
		this.location_y = instance.location_y;
		this.world_id = instance.world_id;
	}
	*/
}
