using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

	public void ActivateOrNotActivate(bool flag) {
		for(var i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag) {
			EventSystem.current.SetSelectedGameObject (firstSelect);
		}
	}

	public int carsol;
	int[] negold = {4,12,20,29,7,15};
	string[] gemeffe = {"HP + 1","HP + 2","HP + 2","HP + 3","MP + 2","MP + 3"};

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

		/*gem1.OnPointerEnter (CGMent1);
		gem2.OnPointerEnter (CGMent2);
		gem3.OnPointerEnter (CGMent3);
		gem4.OnPointerEnter (CGMent4);
		gem5.OnPointerEnter (CGMent5);
		gem6.OnPointerEnter (CGMent6);*/

		Lbuy.onClick.AddListener (Buying);
		Lstop.onClick.AddListener (BaToCh);
		Back.onClick.AddListener (BaStart);
		Hgold = GameManager.instance.Gold;
		Hagold.text = "GOLD" + Hgold.ToString ();
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
		carsol = 0;
	}

	void BackFi(){
		Swindow.SetActive (true);
		GemChoose.SetActive (false);
		Lbuy.interactable = false;
		Lstop.interactable = false;
	}

	void CGEM1(){
		if (Hgold >= negold [carsol]) {
			Buyturn ();
		}
	}

	void Buyturn (){
		Lbuy.interactable = true;
		Lstop.interactable = true;
		gem1.interactable = false;
		gem2.interactable = false;
		gem3.interactable = false;
		gem4.interactable = false;
		gem5.interactable = false;
		gem6.interactable = false;
	}

	void Buying(){
		Hgold -= buygold;
		GameManager.instance.Gold = Hgold;
		GameManager.instance.SaveGold();
		if (Hgold <= buygold) {
			Lbuy.interactable = false;
		}
	}
	void BaToCh(){
		Lbuy.interactable = false;
		Lstop.interactable = false;
		gem1.interactable = true;
		gem2.interactable = true;
		gem3.interactable = true;
		gem4.interactable = true;
		gem5.interactable = true;
		gem6.interactable = true;
	}

	void BaStart(){
		Debug.Log ("back");
		Swindow.SetActive (true);
		GemChoose.SetActive (false);
		Fbuy.interactable = true;
		EventSystem.current.SetSelectedGameObject (firstSelect);
	}

	/*void CGMent1(){
		carsol = 0;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}
	void CGMent2(){
		carsol = 1;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}
	void CGMent3(){
		carsol = 2;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}
	void CGMent4(){
		carsol = 3;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}
	void CGMent5(){
		carsol = 4;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}
	void CGMent6(){
		carsol = 5;
		buygold = negold[carsol];
		effgold = gemeffe[carsol];
		gemef.text = effgold;
		gemgold.text = buygold.ToString ();
	}*/

	void OnTriggerExit(Collider other){
		Swindow.SetActive (false);
		mwindow.SetActive (false);
	}
		
}