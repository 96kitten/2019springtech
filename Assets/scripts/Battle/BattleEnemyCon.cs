using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyCon : MonoBehaviour {

	public ParticleSystem Enpar1;

	GameObject enemy1;
	GameObject enemy2;

	public int EnemyHP;

	public GameObject player;

	public PlayerBattle playerBattle;

	public Slider HPgauge;

	// Use this for initialization
	void Start () {
		enemy1 = (GameObject)Resources.Load ("Prefabs/Enemy");
		enemy2 = (GameObject)Resources.Load ("Prefabs/Enemy2");
		if (GameManager.instance.battleEnemyID == 1) {
			EnemyHP = 13;
			Instantiate (enemy1, new Vector3(4,0.5f,-3), Quaternion.identity);
		}
		if (GameManager.instance.battleEnemyID == 2) {
			EnemyHP = 30;
			Instantiate (enemy2, new Vector3(4,0.5f,-3), Quaternion.identity);
		}
		HPgauge.maxValue = EnemyHP;
		HPgauge.value = EnemyHP;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Eneturn(){

		if (GameManager.instance.battleEnemyID == 1) {
			StartCoroutine (EnemyAttack (2f, Random.Range (2, 6),Enpar1));
		}
		if (GameManager.instance.battleEnemyID == 2) {
			StartCoroutine (EnemyAttack (2f, Random.Range (4, 8),Enpar1));
		}
	}
	private IEnumerator EnemyAttack(float time,int damage,ParticleSystem atk){
		EnemyHP -= playerBattle.AttackDamage;
		HPgauge.value = EnemyHP;
		if (EnemyHP <= 0) {
			if (GameManager.instance.battleEnemyID == 1) {
				GameManager.instance.enemy1count -= 1;
				GameManager.instance.Senemyscounter ();
			}
			if (GameManager.instance.battleEnemyID == 2) {
				GameManager.instance.enemy2count -= 1;
				GameManager.instance.Senemyscounter ();
			}
			playerBattle.winner ();
		}
		if (EnemyHP > 0) {
			atk.Play ();
			yield return new WaitForSeconds (time);
			atk.Stop ();
			yield return new WaitForSeconds (time);
			playerBattle.FairyHP -= damage;
			//turnをtrueに
			playerBattle.turn = true;
			playerBattle.ButtonOn ();
		}
	}

}
