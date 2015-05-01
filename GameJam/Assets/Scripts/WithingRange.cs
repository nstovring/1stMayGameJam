using UnityEngine;
using System.Collections;

public class WithingRange : MonoBehaviour {


//	int dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().damage;

	int dmg = 5;



	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider other) {



		if (other.gameObject.tag == "Enemy" && Input.GetKeyUp(KeyCode.Space)){

			Rigidbody enemeyBody = other.transform.GetComponent<Rigidbody>();

			enemeyBody.AddForce( new Vector3(100,0,100));
			
			other.transform.GetComponent<Enemy>().RecieveDamage(dmg);

	}
}

}//end class
