using UnityEngine;
using System.Collections;

public class Enemy : Entity {
	public bool isDead = false;
	public bool soundEnabled = false;
	bool isAttacking;
	public EnemyMotor enemyMotor;

	new public void RecieveDamage (int damage){
		health -= damage;
		transform.GetComponent<EnemyMotor>().Bounce();
		if(soundEnabled){
		AudioClip clip =GetComponent<AudioSource>().clip;
		GetComponent<AudioSource>().PlayOneShot(clip);
		}
		if (health <= 0) {
			Die();
		}
	}
	new public void Die (){
		isDead = true;
	}
}
