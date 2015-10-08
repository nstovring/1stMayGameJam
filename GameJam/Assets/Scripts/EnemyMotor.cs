using UnityEngine;
using System.Collections;

public class EnemyMotor : MonoBehaviour {
	public Rigidbody rb;
	public GameObject player;
	public Enemy thisEnemy;
	public EnemyMind theMind;
	public int punchForce = 2;
	//public float attackRange = 10f;
	public delegate void EnemyBehaviour();
	EnemyBehaviour enemyBehaviour;
	float stunTime = 0;
	public float distance;
	public bool withinRange;
	public bool attacking;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");
		enemyBehaviour = Stunned;
		theMind = GameObject.FindGameObjectWithTag("EnemyMind").GetComponent<EnemyMind>();
	}

	void FixedUpdate() {
		if(!attacking){
			MovementBehaviour();
		}
		if(enemyBehaviour != null && !thisEnemy.isDead){
		enemyBehaviour();
		}
	}

	public void MovementBehaviour(){
		distance = Vector3.Distance(player.transform.position, transform.position) ;
		if(stunTime >= 3){
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			if(distance > thisEnemy.attackRange){
				rb.velocity.Normalize();
				enemyBehaviour = Move;
			}else{
				rb.velocity.Normalize();
				enemyBehaviour = CircleAround;
			}
		}
	}

	public void Stunned(){
		stunTime += Time.deltaTime *1;
		withinRange = false;
	}

	public void AttackPermission(bool value){
		attacking = value;
	}
	float chargeTime = 2;
	public void Charge(){
		if(chargeTime > 0 && distance> 1){
		transform.LookAt(player.transform.position);
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * thisEnemy.speed*0.5f);
		}else{
			chargeTime = 2;
			theMind.curAttackingEnemies--;
			attacking = false;
			enemyBehaviour = Move;
		}
		chargeTime -= Time.deltaTime *1;
	}

	public void Bounce(){
		stunTime = 0;
		theMind.curAttackingEnemies--;
		attacking = false;
		withinRange = false;
		rb.constraints = RigidbodyConstraints.None;
		rb.AddForce((transform.position + transform.forward)*-punchForce,ForceMode.Impulse);
		rb.AddForce(transform.up*punchForce,ForceMode.Impulse);
		rb.AddForce(transform.forward*-punchForce,ForceMode.Impulse);
		enemyBehaviour = Stunned;
	}

	void CircleAround(){
		transform.LookAt(player.transform.position);
		rb.MovePosition(transform.position + transform.right * Time.deltaTime * thisEnemy.speed/2);
		withinRange = true;
		if(attacking){
			enemyBehaviour = Charge;
		}
	}

	void Move(){
		withinRange = false;
		transform.LookAt(player.transform.position);
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * thisEnemy.speed);
	}
}
