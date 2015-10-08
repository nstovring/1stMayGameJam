using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour, IDamagable, IKillable {
	
	public float speed;
	public int health;
	public int damage;
	public int attackRange;

	void move(){

	}


	void attack(){

	}

	public void RecieveDamage (int damage){}
	
	public void Die (){}
}
