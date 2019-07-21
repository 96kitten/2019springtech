using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerBattle : MonoBehaviour {
	public BattleEnemyCon battleenemy;

	//ステータス
	public int FairyHP;
	public int FairyMP;

	public Text FHP;
	public Text FMP;

	public bool turn = true;

	public GameObject Enemy;

	public int AttackDamage;

	//ボタン選択のやつ
	[SerializeField]
	private GameObject firstSelect;
	[SerializeField]
	private GameObject secoundSelect;

	public void ActivateOrNotActivate(bool flag) {
		for(var i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag) {
			EventSystem.current.SetSelectedGameObject (firstSelect);
		}
	}

	//パーティクル 
	public ParticleSystem Ama1;
	public ParticleSystem Ama2;
	public ParticleSystem Ama3;

	public enum state
	{
		Attack,
		Run,
		Wait
	}

	public enum majic
	{
		Majic1, Majic2, Majic3,Back
	}

	public state currentState;

	public Button AttackB;

	public Button RunB;

	public GameObject BackGround;

	public Button majic1;
	public Button majic2;
	public Button majic3;

	public Button BackB;

	Animator BattleF;


	// Use this for initialization
	void Start () {
		currentState = state.Wait;
		AttackB.interactable = true;
		RunB.interactable = true;
		AttackB.onClick.AddListener (Attack);
		RunB.onClick.AddListener (Run);
		BackB.onClick.AddListener (Back);
		majic1.onClick.AddListener (Majic1);
		majic2.onClick.AddListener (Majic2);
		majic3.onClick.AddListener (Majic3);

		BackGround.SetActive (false);

		BattleF = GetComponent<Animator>();

		StatusManager.instance.BattleStart ();

		FairyHP = PlayerPrefs.GetInt ("HP", 20);
		FairyMP = PlayerPrefs.GetInt ("MP", 30);
		FMP.text = FairyMP.ToString ();
		FHP.text = FairyHP.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		FHP.text = FairyHP.ToString();
	}

	public void ButtonOn(){
		FHP.text = FairyHP.ToString();
		AttackB.interactable = true;
		RunB.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	public void ButtonOff(){
		AttackB.interactable = false;
		RunB.interactable = false;
	}

	public void Attack(){
		currentState = state.Attack;
		AttackB.interactable = false;
		RunB.interactable = false;
		BackGround.SetActive (true);
		EventSystem.current.SetSelectedGameObject (secoundSelect);
		ButtonOff ();
	}
	public void Run(){
		currentState = state.Run;
	}
	public void Back(){
		BackGround.SetActive (false);
		AttackB.interactable = true;
		RunB.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	public void Majic1(){
		if(FairyMP >= 3){
		StartCoroutine (AttackMotion("is_attack1", 1f,5,3,Ama1));
		}
	}

	public void Majic2(){
		if (FairyMP >= 5) {
			StartCoroutine (AttackMotion ("is_attack2", 1f, 12, 5, Ama2));
		}
	}
	public void Majic3(){
		if (FairyMP >= 8) {
			StartCoroutine (AttackMotion ("is_attack3", 2f, 21, 8, Ama3));
		}
	}

	private IEnumerator AttackMotion(string animationName , float time ,int Damage ,int MP,ParticleSystem par){
		BackGround.SetActive (false);
		if(FairyMP < MP){
			ButtonOn ();
		}
		if (FairyMP >= MP) {
			FairyMP -= MP;
			FMP.text = FairyMP.ToString ();
			BattleF.SetBool (animationName, true);
			yield return new WaitForSeconds (time);
			par.Play ();
			BattleF.SetBool (animationName, false);
			yield return new WaitForSeconds (time);
			par.Stop ();
			AttackDamage = Damage;
			//BattleEnemyConのEneturn呼び出し
			battleenemy.Eneturn ();
		}
	}

	public void winner(){
		SceneManager.LoadScene ("Main");
	}
}