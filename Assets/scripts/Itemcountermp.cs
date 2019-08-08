using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Itemcountermp : MonoBehaviour {
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

	public int MaxMPcount;
	public int itemcounter;

	public int I1count;
	public int I2count;
	public int I3count;
	public int I4count;

	public int I1max;
	public int I2max;
	public int I3max;
	public int I4max;

	public int change1;
	public int change2;
	public int change3;
	public int change4;

	bool mcounter = true;

	// Use this for initialization
	void Start () {
		StatusManager.instance.LoadMaxStatus ();
		MaxMPcount = StatusManager.instance.MAXHP;
		MAXCounter.text = MaxMPcount.ToString ();
		ItemManager.instance.LoadItems ();
		I1count = ItemManager.instance.mpi1;
		I2count = ItemManager.instance.mpi2;
		I3count = ItemManager.instance.mpi3;
		I4count = ItemManager.instance.mpi4;
		I1max = ItemManager.instance.mmpi1;
		I2max = ItemManager.instance.mmpi2;
		I3max = ItemManager.instance.mmpi3;
		I4max = ItemManager.instance.mmpi4;
		change1 = ItemManager.instance.MPC1;
		change2 = ItemManager.instance.MPC2;
		change3 = ItemManager.instance.MPC3;
		change4 = ItemManager.instance.MPC4;
		Item1cou.text = I1count.ToString ();
		Item2cou.text = I2count.ToString ();
		Item3cou.text = I3count.ToString ();
		Item4cou.text = I4count.ToString ();
		Sumple1.text = I1max.ToString ();
		Sumple2.text = I2max.ToString ();
		Sumple3.text = I3max.ToString ();
		Sumple4.text = I4max.ToString ();
		mcounter = true;
	}
	
	// Update is called once per frame
	void Update () {
		MaxMPcount = 30 + change1 + change2 + change3 + change4;
		if(I1count+I2count+I3count+I4count >= 20){
			mcounter = false;
		}
	}
	public void itemfirst(bool plus){
		if (mcounter == true) {
			if (plus == true) {
				if (I1count < I1max) {
					I1count += 1;
				}
			}
		}
		if (plus == false) {
			if (I1count > 0) {
				I1count -= 1;
				mcounter = true;
			}
		}
		Item1cou.text = I1count.ToString ();
		change1 = I1count * 3;
		MaxMPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxMPcount.ToString ();
	}

	public void itemsecond(bool plus2){
		if (mcounter == true) {
			if (plus2 == true) {
				if (I2count < I2max) {
					I2count += 1;
					mcounter = true;
				}
			}
		}
		if (plus2 == false) {
			if (I2count > 0) {
				I2count -= 1;
				mcounter = true;
			}
		}
		Item2cou.text = I2count.ToString ();
		change2 = I2count * 3;
		MaxMPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxMPcount.ToString ();
	}

	public void itemthird(bool plus3){
		if (mcounter == true) {
			if (plus3 == true) {
				if (I3count < I3max) {
					I3count += 1;
					mcounter = true;
				}
			}
		}
		if (plus3 == false) {
			if (I3count > 0) {
				I3count -= 1;
			}
		}
		Item3cou.text = I3count.ToString ();
		change3 = I3count * 4;
		MaxMPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxMPcount.ToString ();
	}

	public void itemforth(bool plus4){
		if (mcounter == true) {
			if (plus4 == true) {
				if (I4count < I4max) {
					I4count += 1;
				}
			}
		}
		if (plus4 == false) {
			if (I4count > 0) {
				I4count -= 1;
			}
		}
		Item4cou.text = I4count.ToString ();
		change4 = I4count * 5;
		MaxMPcount = 20 + change1 + change2 + change3 + change4;
		MAXCounter.text = MaxMPcount.ToString ();
	}

	public void bttitle(){
		ItemManager.instance.mpi1 = I1count;
		ItemManager.instance.mpi2 = I2count;
		ItemManager.instance.mpi3 = I3count;
		ItemManager.instance.mpi4 = I4count;
		ItemManager.instance.mmpi1 = I1max;
		ItemManager.instance.mmpi2 = I2max;
		ItemManager.instance.mmpi3 = I3max;
		ItemManager.instance.mmpi4 = I4max;
		ItemManager.instance.MPC1 = change1;
		ItemManager.instance.MPC2 = change2;
		ItemManager.instance.MPC3 = change3;
		ItemManager.instance.MPC4 = change4;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXMP = 30 + change1 + change2 + change3 + change4;
		StatusManager.instance.SaveMaxStatus ();
		SceneManager.LoadScene ("Main");
	}

	public void movemp(){
		ItemManager.instance.mpi1 = I1count;
		ItemManager.instance.mpi2 = I2count;
		ItemManager.instance.mpi3 = I3count;
		ItemManager.instance.mpi4 = I4count;
		ItemManager.instance.mmpi1 = I1max;
		ItemManager.instance.mmpi2 = I2max;
		ItemManager.instance.mmpi3 = I3max;
		ItemManager.instance.mmpi4 = I4max;
		ItemManager.instance.MPC1 = change1;
		ItemManager.instance.MPC2 = change2;
		ItemManager.instance.MPC3 = change3;
		ItemManager.instance.MPC4 = change4;
		ItemManager.instance.SaveItems ();
		StatusManager.instance.MAXMP = 30 + change1 + change2 + change3 + change4;
		StatusManager.instance.SaveMaxStatus ();
		SceneManager.LoadScene ("StatusItemHP");
	}
	public void forcusbutton(){
		firstSelect.Select ();
	}
}
