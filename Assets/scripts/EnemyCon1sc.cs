using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon1sc : MonoBehaviour {

	public GameObject Enemy1;
	public GameObject Enemy2;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 7; i++) {
			GameObject enemy = Instantiate(Enemy1) as GameObject;
			enemy.transform.position = new Vector3(Random.Range(-129,23),0.5f, Random.Range(-118,8));
		}
		for (int i = 0; i < 5; i++) {
			GameObject enemy2 = Instantiate(Enemy2) as GameObject;
			enemy2.transform.position = new Vector3(Random.Range(100,200),0.5f, Random.Range(0,100));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
