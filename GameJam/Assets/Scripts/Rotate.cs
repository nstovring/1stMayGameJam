using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = 50f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
	}
}
