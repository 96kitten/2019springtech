using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ItemCounter: MonoBehaviour {

	[SerializeField]
	private GameObject firstSelect;

	public void ActivateOrNotActivate(bool flag) {
		for(var i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag) {
			EventSystem.current.SetSelectedGameObject (firstSelect);
		}
	}

	//HP
	public Text Item1cou;
	public Text Item2cou;
	public Text Item3cou;
	public Text Item4cou;
	public Text Counter;
	public Text MAXCounter;

	public Button up1;
	public Button up2;
	public Button up3;
	public Button up4;
	public Button down1;
	public Button down2;
	public Button down3;
	public Button down4;

	public Button back;
	public Button mpgo;

	public int MaxHPcount;
	public int itemcounter;
	//装備数
	public int I1count;
	public int I2count;
	public int I3count;
	public int I4count;
	//所持数
	public int I1max;
	public int I2max;
	public int I3max;
	public int I4max;
	//表示する個数
	public int text1;
	public int text2;
	public int text3;
	public int text4;
	//変化数
	public int change1;
	public int change2;
	public int change3;
	public int change4;

	bool mcounter = true;

	// Use this for initialization
	void Start () {
		StatusManager.instance.LoadMaxStatus ();
		MaxHPcount = StatusManager.instance.MAXHP;
		MAXCounter.text = MaxHPcount.ToString ();
		ItemManager.instance.LoadItems ();
		I1count = ItemManager.instance.hpi1;
		I2count = ItemManager.instance.hpi2;
		I3count = ItemManager.instance.hpi3;
		I4count = ItemManager.instance.hpi4;
		I1max = ItemManager.instance.mhpi1;
		I2max = ItemManager.instance.mhpi2;
		I3max = ItemManager.instance.mhpi3;
		I4max = ItemManager.instance.mhpi4;
		text1 = I1max - I1count;
		text2 = I2max - I2count;
		text3 = I3max - I3count;
		text4 = I4max - I4count;
		Item1cou.text = text1.ToString ();
		Item2cou.text = text2.ToString ();
		Item3cou.text = text3.ToString ();
		Item4cou.text = text4.ToString ();
		mcounter = true;
	}
	
	// Update is called once per frame
	void Update () {
		MaxHPcount = 20 + change1 + change2 + change3 + change4;
		if(I1count+I2count+I3count+I4count >= 20){
			mcounter = false;
		}
	}

	public void itemfirst(bool plus){
		if (mcounter == true) {
			if (plus == true) {
				if (I1count < I1max) {
					I1count += 1;
					text1 = I1max - I1count;
				}
			}
		}
		if (plus == false) {
			if (I1count > 0) {
				I1count -= 1;
				text1 = I1max - I1count;
				mcounter = true;
			}
		}
		Item1cou.text = text1.ToString ();
		change1 = I1count;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemsecond(bool plus2){
		if (mcounter == true) {
			if (plus2 == true) {
				if (I2count < I2max) {
					I2count += 1;
					text2 = I2max - I2count;
					mcounter = true;
				}
			}
		}
		if (plus2 == false) {
			if (I2count > 0) {
				I2count -= 1;
				text2 = I2max - I2count;
				mcounter = true;
			}
		}
		Item2cou.text = text2.ToString ();
		change2 = I2count * 2;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemthird(bool plus3){
		if (mcounter == true) {
			if (plus3 == true) {
				if (I3count < I3max) {
					I3count += 1;
					text3 = I3max - I3count;
					mcounter = true;
				}
			}
		}
		if (plus3 == false) {
			if (I3count > 0) {
				I3count -= 1;
				text3 = I3max - I3count;
			}
		}
		Item3cou.text = text3.ToString ();
		change3 = I3count * 2;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemforth(bool plus4){
		if (mcounter == true) {
			if (plus4 == true) {
				if (I4count < I4max) {
					I4count += 1;
					text4 = I4max - I4count;
				}
			}
		}
		if (plus4 == false) {
			if (I4count > 0) {
				I4count -= 1;
				text4 = I4max - I4count;
			}
		}
		Item4cou.text = text4.ToString ();
		change4 = I4count * 3;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void bttitle(){
		ItemManager.instance.hpi1 = I1count;
		ItemManager.instance.hpi2 = I2count;
		ItemManager.instance.hpi3 = I3count;
		ItemManager.instance.hpi4 = I4count;
		ItemManager.instance.mhpi1 = I1max;
		ItemManager.instance.mhpi2 = I2max;
		ItemManager.instance.mhpi3 = I3max;
		ItemManager.instance.mhpi4 = I4max;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXHP = 20 + change1 + change2 + change3 + change4;
		SceneManager.LoadScene ("Main");
	}

	public void movemp(){
		ItemManager.instance.hpi1 = I1count;
		ItemManager.instance.hpi2 = I2count;
		ItemManager.instance.hpi3 = I3count;
		ItemManager.instance.hpi4 = I4count;
		ItemManager.instance.mhpi1 = I1max;
		ItemManager.instance.mhpi2 = I2max;
		ItemManager.instance.mhpi3 = I3max;
		ItemManager.instance.mhpi4 = I4max;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXHP = 20 + change1 + change2 + change3 + change4;
		SceneManager.LoadScene ("StatusItemMP");
	}
}
