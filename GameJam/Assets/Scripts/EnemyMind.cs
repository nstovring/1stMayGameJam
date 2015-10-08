using UnityEngine;
using System.Collections;

public class EnemyMind : MonoBehaviour {

	public EnemyMotor[] enemies;
	EnemyMotor[] attackEnemies;
	public int maxAttackingEnemies = 3;
	// Use this for initialization
	void Start () {
	
	}
	public void InitializeMind(int maxEnemies){
		enemies = new EnemyMotor[maxEnemies];
		attackEnemies = new EnemyMotor[maxEnemies];
	}

	public void FillEnemyArray(int position, EnemyMotor enemy){
		enemies[position] = enemy;
	}
	public void UpdateArrays(){
		if(curAttackingEnemies < maxAttackingEnemies){
		//Debug.Log ("Finding attacking enemies");
		int i = 0;
		foreach(EnemyMotor enemy in enemies){
			if(enemy.withinRange && !enemy.attacking && !enemy.thisEnemy.isDead){
				attackEnemies[i] = enemy;
				i++;
				}
		}
			attackEnemies[Random.Range(0,i)].AttackPermission(true);
			curAttackingEnemies++;
		}
	}
	public bool allSpawned;
	// Update is called once per frame
	public int curAttackingEnemies;
	void LateUpdate () {
		if(allSpawned){
		UpdateArrays();
		}
	}
}
