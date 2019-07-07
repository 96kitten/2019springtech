using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyCon : MonoBehaviour {

	GameObject enemy1;
	GameObject enemy2;

	public GameObject player;

	// Use this for initialization
	void Start () {
		enemy1 = (GameObject)Resources.Load ("Prefabs/Enemy");
		enemy2 = (GameObject)Resources.Load ("Prefabs/Enemy2");
		if (GameManager.instance.battleEnemyID == 1) {
			Instantiate (enemy1, new Vector3(4,0.5f,-3), Quaternion.identity);
		}
		if (GameManager.instance.battleEnemyID == 2) {
			Instantiate (enemy2, new Vector3(4,0.5f,-3), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerBattle.turn == false){
			StartCoroutine (EnemyAttack (1f,Random.Range(2,6)));
		}
	}
	private IEnumerator EnemyAttack(float time,int damage){
		yield return new WaitForSeconds (time);
		PlayerBattle.FairyHP -= damage;
		PlayerBattle.turn = true;
	}

}
