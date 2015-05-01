using UnityEngine;
using System.Collections;

public class followTarget : MonoBehaviour {
	public Rigidbody rb;
	public GameObject player;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(rb.velocity);
		transform.LookAt(player.transform.position);
	
	}
	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
	}
}
