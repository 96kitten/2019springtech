using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyCon : MonoBehaviour {

	public ParticleSystem Enpar1;

	GameObject enemy1;
	GameObject enemy2;
	GameObject enemy3;
	GameObject enemy4;

	GameObject baenemy;

	public int EnemyHP;

	public GameObject player;

	public PlayerBattle playerBattle;

	public Slider HPgauge;

	public Animator atanimation;

	// Use this for initialization
	void Start () {
		enemy1 = (GameObject)Resources.Load ("Prefabs/Enemy1wolf");
		enemy2 = (GameObject)Resources.Load ("Prefabs/Enemy2gob");
		enemy3 = (GameObject)Resources.Load ("Prefabs/Enemy3Troll");
		enemy4 = (GameObject)Resources.Load ("Prefabs/Enemy4Hgob");
		if (GameManager.instance.battleEnemyID == 1) {
			EnemyHP = 13;
			baenemy = Instantiate (enemy1, new Vector3(4,0.5f,-3), Quaternion.identity);
		}
		if (GameManager.instance.battleEnemyID == 2) {
			EnemyHP = 30;
		    baenemy = Instantiate (enemy2, new Vector3(4,0,-3), Quaternion.identity);
		}
		if (GameManager.instance.battleEnemyID == 3) {
			EnemyHP = 100;
			baenemy = Instantiate (enemy3, new Vector3(4,0,-3), Quaternion.identity);
		}
		if (GameManager.instance.battleEnemyID == 4) {
			EnemyHP = 50;
			baenemy = Instantiate (enemy4, new Vector3(4,0,-3), Quaternion.identity);
		}
		atanimation = baenemy.GetComponent<Animator> ();
		HPgauge.maxValue = EnemyHP;
		HPgauge.value = EnemyHP;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Eneturn(){

		if (GameManager.instance.battleEnemyID == 1) {
			StartCoroutine (EnemyAttack (2f, Random.Range (3, 5),Random.Range(5,9)));
		}
		if (GameManager.instance.battleEnemyID == 2) {
			StartCoroutine (EnemyAttack (2f, Random.Range (6, 8),Random.Range(10,17)));
		}
		if (GameManager.instance.battleEnemyID == 3) {
			StartCoroutine (EnemyAttack (2f, Random.Range (10, 17),Random.Range(18,25)));
		}
		if (GameManager.instance.battleEnemyID == 4) {
			StartCoroutine (EnemyAttack (2f, Random.Range (8, 13),Random.Range(26,35)));
		}
	}
	private IEnumerator EnemyAttack(float time,int damage,int getG){
		EnemyHP -= playerBattle.AttackDamage;
		HPgauge.value = EnemyHP;
		if (EnemyHP <= 0) {
			atanimation.SetBool ("enlose", true);
			yield return new WaitForSeconds (time);
			if (GameManager.instance.battleEnemyID == 1) {
				GameManager.instance.enemy1count -= 1;
				GameManager.instance.Senemyscounter ();
				GameManager.instance.Gold += getG;
				GameManager.instance.SaveGold ();
			}
			if (GameManager.instance.battleEnemyID == 2) {
				GameManager.instance.enemy2count -= 1;
				GameManager.instance.Senemyscounter ();
				GameManager.instance.Gold += getG;
				GameManager.instance.SaveGold ();
			}
			if (GameManager.instance.battleEnemyID == 3) {
				GameManager.instance.enemy3count -= 1;
				GameManager.instance.Senemyscounter ();
				GameManager.instance.Gold += getG;
				GameManager.instance.SaveGold ();
			}
			if (GameManager.instance.battleEnemyID == 4) {
				GameManager.instance.enemy4count -= 1;
				GameManager.instance.Senemyscounter ();
				GameManager.instance.Gold += getG;
				GameManager.instance.SaveGold ();
			}
			playerBattle.winner ();
		}
		if (EnemyHP > 0) {
			atanimation.SetBool ("enattack", true);
			yield return new WaitForSeconds (time);
			atanimation.SetBool ("enattack", false);
			playerBattle.FairyHP -= damage;
			//turnをtrueに
			playerBattle.turn = true;
			playerBattle.ButtonOn ();
		}
	}

}
