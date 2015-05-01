using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Player :  Entity {
=======
public class Player : Entity {
>>>>>>> origin/master

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))* speed;
	
	}



	void OnCollisionEnter(Collision other ){
		
		
		//Enemy hits
		if (other.gameObject.tag == "Enemy"){

			Rigidbody enemeyBody = other.transform.GetComponent<Rigidbody>();
			
			enemeyBody.AddForce( new Vector3(100000,0,100000));

			other.transform.GetComponent<Enemy>().RecieveDamage(this.damage);

			//enemeyBody.velocity * -1

			//Destroy(other.gameObject); //will kill what hits
			
			/*
			Destroy(gameObject); //will kill us
			Application.LoadLevel(0); //restarts game
			Application.LoadLevel(Application.loadedLevel);//will restart level
			Application.Quit(); //stops game

			*/
		}

	}
}
