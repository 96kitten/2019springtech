using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ItemCounter: MonoBehaviour {

	[SerializeField]
	private Button firstSelect;

	public void ActivateOrNotActivate(bool flag) {
		for(var i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag) {
			EventSystem.current.SetSelectedGameObject (firstSelect.gameObject);
		}
	}

	//HP
	public Text Item1cou;
	public Text Item2cou;
	public Text Item3cou;
	public Text Item4cou;
	public Text Counter;
	public Text MAXCounter;

	public Text Sumple1;
	public Text Sumple2;
	public Text Sumple3;
	public Text Sumple4;

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
	//変化数
	public int change1;
	public int change2;
	public int change3;
	public int change4;

	public int HaveJem;

	bool mcounter = true;

	public Text HGold;

	public int MyGold;

	// Use this for initialization
	void Start () {
		forcusbutton ();
		GameManager.instance.LoadGold ();
		MyGold = GameManager.instance.Gold;

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
		change1 = ItemManager.instance.HPC1;
		change2 = ItemManager.instance.HPC2;
		change3 = ItemManager.instance.HPC3;
		change4 = ItemManager.instance.HPC4;
		Item1cou.text = I1count.ToString ();
		Item2cou.text = I2count.ToString ();
		Item3cou.text = I3count.ToString ();
		Item4cou.text = I4count.ToString ();
		Sumple1.text = I1max.ToString ();
		Sumple2.text = I2max.ToString ();
		Sumple3.text = I3max.ToString ();
		Sumple4.text = I4max.ToString ();
		mcounter = true;
		HGold.text = MyGold.ToString();
		HaveJem = I1count + I2count + I3count + I4count;
		Counter.text = HaveJem.ToString ();
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
					HaveJem = I1count + I2count + I3count + I4count;
					Counter.text = HaveJem.ToString ();
				}
			}
		}
		if (plus == false) {
			if (I1count > 0) {
				I1count -= 1;
				mcounter = true;
				HaveJem = I1count + I2count + I3count + I4count;
				Counter.text = HaveJem.ToString ();
			}
		}
		Item1cou.text = I1count.ToString ();
		change1 = I1count;
		MaxHPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemsecond(bool plus2){
		if (mcounter == true) {
			if (plus2 == true) {
				if (I2count < I2max) {
					I2count += 1;
					mcounter = true;
					HaveJem = I1count + I2count + I3count + I4count;
					Counter.text = HaveJem.ToString ();
				}
			}
		}
		if (plus2 == false) {
			if (I2count > 0) {
				I2count -= 1;
				mcounter = true;
				HaveJem = I1count + I2count + I3count + I4count;
				Counter.text = HaveJem.ToString ();
			}
		}
		Item2cou.text = I2count.ToString ();
		change2 = I2count * 2;
		MaxHPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemthird(bool plus3){
		if (mcounter == true) {
			if (plus3 == true) {
				if (I3count < I3max) {
					I3count += 1;
					mcounter = true;
					HaveJem = I1count + I2count + I3count + I4count;
					Counter.text = HaveJem.ToString ();
				}
			}
		}
		if (plus3 == false) {
			if (I3count > 0) {
				I3count -= 1;
				HaveJem = I1count + I2count + I3count + I4count;
				Counter.text = HaveJem.ToString ();
			}
		}
		Item3cou.text = I3count.ToString ();
		change3 = I3count * 2;
		MaxHPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxHPcount.ToString ();
	}

	public void itemforth(bool plus4){
		if (mcounter == true) {
			if (plus4 == true) {
				if (I4count < I4max) {
					I4count += 1;
					HaveJem = I1count + I2count + I3count + I4count;
					Counter.text = HaveJem.ToString ();
				}
			}
		}
		if (plus4 == false) {
			if (I4count > 0) {
				I4count -= 1;
				HaveJem = I1count + I2count + I3count + I4count;
				Counter.text = HaveJem.ToString ();
			}
		}
		Item4cou.text = I4count.ToString ();
		change4 = I4count * 3;
		MaxHPcount = 20 + change1 + change2 + change3 + change4;
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
		ItemManager.instance.HPC1 = change1;
		ItemManager.instance.HPC2 = change2;
		ItemManager.instance.HPC3 = change3;
		ItemManager.instance.HPC4 = change4;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXHP = 20 + change1 + change2 + change3 + change4;
		StatusManager.instance.SaveMaxStatus ();
		SceneManager.LoadScene (StatusManager.instance.NSceNa);
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
		ItemManager.instance.HPC1 = change1;
		ItemManager.instance.HPC2 = change2;
		ItemManager.instance.HPC3 = change3;
		ItemManager.instance.HPC4 = change4;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXHP = 20 + change1 + change2 + change3 + change4;
		StatusManager.instance.SaveMaxStatus ();
		SceneManager.LoadScene ("StatusItemMP");
	}

	public void forcusbutton(){
		firstSelect.Select ();
	}
}
