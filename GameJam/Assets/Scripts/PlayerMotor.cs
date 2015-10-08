using UnityEngine;
using System.Collections;

public class PlayerMotor: MonoBehaviour{
	private float speed = 5;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		speed = GetComponent<Player>().speed;
		//rb.velocity += new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))* speed;
		rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))* speed);
	}
}
