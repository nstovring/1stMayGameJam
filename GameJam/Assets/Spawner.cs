using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	float spawnRate = 10f;

	public GameObject enemyPrefab;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set(Random.Range(-10.0F, -5.0F),10f,0f);

	}
}
