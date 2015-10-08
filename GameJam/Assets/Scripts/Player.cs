using UnityEngine;
using System.Collections;

public class Player : Entity {

	public bool immortal = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other ){
		//Enemy hits
		if (other.gameObject.tag == "Enemy" && !immortal){
			RecieveDamage(2);
		}
		
	}
	
	new void RecieveDamage (int damage){
		health -= damage;
		
		if (health <= 0) {
			Die();
		}
	}
	
	new void Die (){
		Application.LoadLevel(0); //restarts game
	}
}
