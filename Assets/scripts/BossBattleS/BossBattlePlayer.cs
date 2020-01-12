using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BossBattlePlayer : MonoBehaviour {
	public BossBattleSystem battleeboss;

	//ステータス
	public int FairyHP;
	public int FairyMP;

	public Text FHP;
	public Text FMP;

	public float RecHP;
	public int RecHPGo;

	public bool turn = true;

	public GameObject Enemy;

	public int AttackDamage;

	//ボタン選択のやつ
	[SerializeField]
	private GameObject firstSelect;
	[SerializeField]
	private GameObject secoundSelect;
	[SerializeField]
	private GameObject thirdSelect;
	[SerializeField]
	private GameObject forthSelect;

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
	public ParticleSystem Ama4;
	public ParticleSystem Ama5;
	public ParticleSystem Ama6;

	public enum state
	{
		Attack,
		Run,
		Wait
	}

	public enum majic
	{
		Majic1, Majic2, Majic3,Majic4,Majic5,Majic6,Back
	}

	public state currentState;

	public Button AttackB;

	public GameObject BackGround;

	public Button majic1;
	public Button majic2;
	public Button majic3;
	public Button majic4;
	public Button majic5;
	public Button majic6;

	public Button BackB;

	public Button NextP;
	public Button BackP;


	Animator BattleF;


	// Use this for initialization
	void Start () {
		currentState = state.Wait;
		AttackB.interactable = true;
		AttackB.onClick.AddListener (Attack);
		BackB.onClick.AddListener (Back);
		majic1.onClick.AddListener (Majic1);
		majic2.onClick.AddListener (Majic2);
		majic3.onClick.AddListener (Majic3);
		majic4.onClick.AddListener (Majic4);
		majic5.onClick.AddListener (Majic5);
		majic6.onClick.AddListener (Majic6);
		NextP.onClick.AddListener (GTNextPage);
		BackP.onClick.AddListener (GTBackPage);

		BackGround.SetActive (false);

		NextP.gameObject.SetActive(false);
		BackP.gameObject.SetActive(false);

		majic4.gameObject.SetActive (false);
		majic5.gameObject.SetActive (false);
		majic6.gameObject.SetActive (false);

		BattleF = GetComponent<Animator>();

		StatusManager.instance.BattleStart ();

		FairyHP = PlayerPrefs.GetInt ("HP", 20);
		FairyMP = PlayerPrefs.GetInt ("MP", 30);
		FMP.text = FairyMP.ToString ();
		FHP.text = FairyHP.ToString ();

		RecHP = StatusManager.instance.MAXHP / 4;
		RecHPGo = Mathf.CeilToInt (RecHP);

		if(StatusManager.instance.ReMaj4 == 1 || StatusManager.instance.ReMaj5 == 1 || StatusManager.instance.ReMaj6 == 1){
			NextP.gameObject.SetActive(true);
			BackP.gameObject.SetActive(true);
			BackP.interactable = (false);
		}
	}

	// Update is called once per frame
	void Update () {
		FHP.text = FairyHP.ToString();
	}

	public void ButtonOn(){
		FHP.text = FairyHP.ToString();
		AttackB.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	public void ButtonOff(){
		AttackB.interactable = false;
	}

	public void Attack(){
		currentState = state.Attack;
		AttackB.interactable = false;
		BackGround.SetActive (true);
		EventSystem.current.SetSelectedGameObject (secoundSelect);
		ButtonOff ();
	}
	public void Back(){
		BackGround.SetActive (false);
		AttackB.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	public void GTNextPage(){
		majic1.gameObject.SetActive (false);
		majic2.gameObject.SetActive (false);
		majic3.gameObject.SetActive (false);
		if(StatusManager.instance.ReMaj4 == 1){
			majic4.gameObject.SetActive (true);
		}
		if (StatusManager.instance.ReMaj5 == 1) {
			majic5.gameObject.SetActive (true);
		}
		if (StatusManager.instance.ReMaj6 == 1) {
			majic6.gameObject.SetActive (true);
		}
		NextP.interactable = (false);
		BackP.interactable = (true);
		EventSystem.current.SetSelectedGameObject (thirdSelect);
	}

	public void GTBackPage(){
		majic1.gameObject.SetActive (true);
		majic2.gameObject.SetActive (true);
		majic3.gameObject.SetActive (true);
		majic4.gameObject.SetActive (false);
		majic5.gameObject.SetActive (false);
		majic6.gameObject.SetActive (false);
		BackP.interactable = (false);
		NextP.interactable = (true);
		EventSystem.current.SetSelectedGameObject (forthSelect);
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
	public void Majic4(){
		if (FairyMP >= 10) {
			StartCoroutine (AttackMotion ("is_attack4", 2f, 0, 10, Ama4));
		}
	}
	public void Majic5(){
		if (FairyMP >= 13) {
			StartCoroutine (AttackMotion ("is_attack5", 2f, 35, 13, Ama5));
		}
	}
	public void Majic6(){
		if (FairyMP >= 17 && FairyHP > 7) {
			StartCoroutine (AttackMotion ("is_attack6", 2f, 42, 17, Ama6));
		}
	}

	private IEnumerator AttackMotion(string animationName , float time ,int Damage ,int MP,ParticleSystem par){
		BackGround.SetActive (false);
		if(FairyMP < MP){
			ButtonOn ();
		}
		if (FairyMP >= MP) {
			FairyMP -= MP;
			StatusManager.instance.PlayerMP = FairyMP;
			StatusManager.instance.Status ();
			FMP.text = FairyMP.ToString ();
			BattleF.SetBool (animationName, true);
			yield return new WaitForSeconds (time);
			par.Play ();
			BattleF.SetBool (animationName, false);
			yield return new WaitForSeconds (time);
			par.Stop ();
			AttackDamage = Damage;
			if(Damage == 0){
				FairyHP += RecHPGo;
				if(FairyHP > StatusManager.instance.MAXHP){
					FairyHP = StatusManager.instance.MAXHP;
				}
				FHP.text = FairyHP.ToString ();
			}
			if (Damage == 42) {
				FairyHP -= 7;
				FHP.text = FairyHP.ToString ();
			}
			majic1.gameObject.SetActive (true);
			majic2.gameObject.SetActive (true);
			majic3.gameObject.SetActive (true);
			majic4.gameObject.SetActive (false);
			majic5.gameObject.SetActive (false);
			majic6.gameObject.SetActive (false);
			//BattleEnemyConのEneturn呼び出し
			battleeboss.Eneturn ();
		}
	}

	public void winner(){
		StatusManager.instance.PlayerHP = FairyHP;
		StatusManager.instance.PlayerMP = FairyMP;
		StatusManager.instance.Status ();
		GameManager.instance.Gold += 300;
		GameManager.instance.bosscount = 0;
		GameManager.instance.Senemyscounter ();
		GameManager.instance.SaveGold ();
		SceneManager.LoadScene ("BossScene");
	}
}
