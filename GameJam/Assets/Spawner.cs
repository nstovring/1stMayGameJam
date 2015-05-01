using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	float spawnRate = 10f;
	float spawnTimer;
	public GameObject enemyPrefab;
	public GameObject playerPrefab;

	Vector3 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(Random.Range(-25.0F, -15.0F),0,0);
		spawnRate += Time.deltaTime * 1;
		if(spawnRate >= 3){
			SpawnEnemy();
			spawnRate = 0;
		}
	}

	void SpawnEnemy(){
		Instantiate(enemyPrefab,transform.position,Quaternion.identity);
	}
}
