using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = 50f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set(Random.Range(-10.0F, -5.0F),10f,0f);
		transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
	}
}
