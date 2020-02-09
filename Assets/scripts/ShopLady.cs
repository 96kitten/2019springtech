using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopLady : MonoBehaviour {

	public Text talk;
	public GameObject mwindow;
	public GameObject Swindow;
	public GameObject GemChoose;

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

	public int carsol;
	int[] negold = {4,7,13,18,7,11,16,22};
	string[] gemeffe = {"HP + 1","HP + 2","HP + 2","HP + 3","MP + 2","MP + 3","MP + 4","MP + 5"};

	//最初のボタン
	public Button Fbuy;
	public Button Fsell;

	//商品選び
	public Button gem1;
	public Button gem2;
	public Button gem3;
	public Button gem4;
	public Button gem5;
	public Button gem6;
	public Button Back;

	//購入
	public Button Lbuy;
	public Button Lstop;

	public int Hgold;
	public Text Hagold;

	public Text gemef;
	public Text gemgold;

	public int buygold;
	public string effgold;

	 
	void Start () {
		Swindow.SetActive (false);
		Fbuy.onClick.AddListener (FIBuy);
		Back.onClick.AddListener (BackFi);
		gem1.onClick.AddListener (CGEM1);
		gem2.onClick.AddListener (CGEM2);
		gem3.onClick.AddListener (CGEM3);
		gem4.onClick.AddListener (CGEM4);
		gem5.onClick.AddListener (CGEM5);
		gem6.onClick.AddListener (CGEM6);

		ItemManager.instance.LoadItems();
		Lbuy.onClick.AddListener (Buying);
		Lstop.onClick.AddListener (BaToCh);
		Back.onClick.AddListener (BaStart);
		Hgold = GameManager.instance.Gold;
		Hagold.text = Hgold.ToString ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			talk.text = "いらっしゃいませ！何か買っていく？";
			mwindow.SetActive (true);
			Swindow.SetActive (true);
			GemChoose.SetActive (false);
			Lbuy.interactable = false;
			Lstop.interactable = false;
		}
	}


	void FIBuy(){
		GemChoose.SetActive (true);
		Fbuy.interactable = false;
		EventSystem.current.SetSelectedGameObject (secoundSelect);
		talk.text = "こんなジェムはどう？";
	}

	void BackFi(){
		Swindow.SetActive (true);
		GemChoose.SetActive (false);
		Lbuy.interactable = false;
		Lstop.interactable = false;
	}

	void CGEM1(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 0;
	    }
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 4;
		}
		gemef.text = gemeffe [carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}
	void CGEM2(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 1;
		}
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 5;
		}
		gemef.text = gemeffe[carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}
	void CGEM3(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 2;
		}
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 6;
		}
		gemef.text = gemeffe[carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}
	void CGEM4(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 3;
		}
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 7;
		}
		gemef.text = gemeffe[carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}
	void CGEM5(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 4;
		}
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 1;
		}
		gemef.text = gemeffe[carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}
	void CGEM6(){
		if (SceneManager.GetActiveScene ().name == "MountainTown"){
			carsol = 5;
		}
		if (SceneManager.GetActiveScene ().name == "SeaSideTown"){
			carsol = 2;
		}
		gemef.text = gemeffe[carsol];
		gemgold.text = negold [carsol].ToString () + "G";
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}

	void Buyturn (){
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		EventSystem.current.SetSelectedGameObject (thirdSelect);
		Lbuy.interactable = true;
		Lstop.interactable = true;
		Back.interactable = false;
		gem1.interactable = false;
		gem2.interactable = false;
		gem3.interactable = false;
		gem4.interactable = false;
		gem5.interactable = false;
		gem6.interactable = false;
		talk.text = "これにするの？";
	}

	void Buying(){
		Hgold -= buygold;
		Hagold.text = Hgold.ToString();
		GameManager.instance.Gold = Hgold;
		GameManager.instance.SaveGold();
		if (carsol == 0) {
			ItemManager.instance.mhpi1 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 1) {
			ItemManager.instance.mhpi2 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 2) {
			ItemManager.instance.mhpi3 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 3) {
			ItemManager.instance.mhpi4 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 4) {
			ItemManager.instance.mmpi1 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 5) {
			ItemManager.instance.mmpi2 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 6) {
			ItemManager.instance.mmpi3 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (carsol == 7) {
			ItemManager.instance.mmpi4 += 1;
			ItemManager.instance.ItemGet ();
		}
		if (Hgold <= buygold) {
			Lbuy.interactable = false;
			EventSystem.current.SetSelectedGameObject (forthSelect);
		}
		talk.text = "ありがとね！";
	}
	void BaToCh(){
		EventSystem.current.SetSelectedGameObject (secoundSelect);
		Lbuy.interactable = false;
		Lstop.interactable = false;
		gem1.interactable = true;
		gem2.interactable = true;
		gem3.interactable = true;
		gem4.interactable = true;
		gem5.interactable = true;
		gem6.interactable = true;
		Back.interactable = true;
	}

	void BaStart(){
		Swindow.SetActive (true);
		GemChoose.SetActive (false);
		Fbuy.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	public void OnPointerEnter(){
		Debug.Log ("On");

		if (this.gameObject.name == "gem") {
			carsol = 0;
		}if (this.gameObject.name == "gem2") {
			carsol = 1;
		}if (this.gameObject.name == "gem3") {
			carsol = 2;
		}if (this.gameObject.name == "gem4") {
			carsol = 3;
		}if (this.gameObject.name == "gem5") {
			carsol = 4;
		}if (this.gameObject.name == "gem6") {
			carsol = 5;
		}
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString () + "G";
	}

	void OnTriggerExit(Collider other){
		Swindow.SetActive (false);
		mwindow.SetActive (false);
	}
		
}