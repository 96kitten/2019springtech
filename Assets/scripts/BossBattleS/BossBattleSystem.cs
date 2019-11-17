﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleSystem : MonoBehaviour {

	public int EnemyHP;

	public GameObject player;

	public BossBattlePlayer playerBoss;

	public Slider HPgauge;

	public Animator atanimation;

	void Start () {
		atanimation = this.GetComponent<Animator> ();
		EnemyHP = 500;
		HPgauge.maxValue = EnemyHP;
		HPgauge.value = EnemyHP;
	}

	void Update () {
		
	}

	public void Eneturn(){
			StartCoroutine (EnemyAttack (2f, Random.Range (15, 24)));
	}

	private IEnumerator EnemyAttack(float time,int damage){
		EnemyHP -= playerBoss.AttackDamage;
		HPgauge.value = EnemyHP;
		if (EnemyHP <= 0) {
			atanimation.SetBool ("enlose", true);
			yield return new WaitForSeconds (time);
				GameManager.instance.enemy2count -= 1;
				GameManager.instance.Senemyscounter ();
			playerBoss.winner ();
		}
		if (EnemyHP > 0) {
			atanimation.SetBool ("enattack", true);
			yield return new WaitForSeconds (time);
			atanimation.SetBool ("enattack", false);
			playerBoss.FairyHP -= damage;
			//turnをtrueに
			playerBoss.turn = true;
			playerBoss.ButtonOn ();
		}
	}
}