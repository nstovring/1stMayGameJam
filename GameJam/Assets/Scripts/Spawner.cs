using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnRate = 5f;
	float spawnTimer;
	int spawnCount = 0;
	public int spawnMax = 50;
	public Sprite [] enemySprites;
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	EnemyMind enemyMind;
	
	Vector3 position;
	
	// Use this for initialization
	void Start () {
		enemyMind = GameObject.FindGameObjectWithTag("EnemyMind").GetComponent<EnemyMind>();
		enemyMind.InitializeMind(spawnMax);
	}
	
	// Update is called once per frame
	void Update () {
		Spawn();
	}
	void Spawn(){
		while(spawnCount < spawnMax){
		transform.localPosition = new Vector3(Random.Range(-25.0F, -15.0F),0,0);
		spawnRate -= Time.deltaTime * 1*spawnMax/7; //Divided by arbitrary number because they need to sorround player
		if(spawnRate <= 0 && spawnCount < spawnMax){
			SpawnEnemy();
			spawnCount++;
			Debug.Log("Spawned " + spawnCount);
			spawnRate = 1;
			}else{
				break;
			}
		}
		if(spawnCount >= spawnMax){
			//Debug.Log("AllSpawned");
			enemyMind.allSpawned = true;
		}
	}
	
	void SpawnEnemy(){
		GameObject clone =Instantiate(enemyPrefab,transform.position,Quaternion.identity) as GameObject;
		enemyMind.FillEnemyArray(spawnCount,clone.GetComponent<EnemyMotor>());
		clone.transform.GetComponent<SpriteRenderer> ().sprite = enemySprites [Random.Range (0, enemySprites.Length)];
	}
}