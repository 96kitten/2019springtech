using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public static ItemManager instance;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public int hpi1;
	public int hpi2;
	public int hpi3;
	public int hpi4;

	public int mpi1;
	public int mpi2;
	public int mpi3;
	public int mpi4;


	public int mhpi1;
	public int mhpi2;
	public int mhpi3;
	public int mhpi4;

	public int mmpi1;
	public int mmpi2;
	public int mmpi3;
	public int mmpi4;

	public int HPC1;
	public int HPC2;
	public int HPC3;
	public int HPC4;

	public int MPC1;
	public int MPC2;
	public int MPC3;
	public int MPC4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveItems(){
		PlayerPrefs.SetInt ("HPINUM",hpi1);
		PlayerPrefs.SetInt ("HPINUM2",hpi2);
		PlayerPrefs.SetInt ("HPINUM3",hpi3);
		PlayerPrefs.SetInt ("HPINUM4",hpi4);
		PlayerPrefs.SetInt ("MPINUM",mpi1);
		PlayerPrefs.SetInt ("MPINUM2",mpi2);
		PlayerPrefs.SetInt ("MPINUM3",mpi3);
		PlayerPrefs.SetInt ("MPINUM4",mpi4);

		PlayerPrefs.SetInt ("MHPNUM",mhpi1);
		PlayerPrefs.SetInt ("MHPNUM2",mhpi2);
		PlayerPrefs.SetInt ("MHPNUM3",mhpi3);
		PlayerPrefs.SetInt ("MHPNUM4",mhpi4);
		PlayerPrefs.SetInt ("MMPNUM",mmpi1);
		PlayerPrefs.SetInt ("MMPNUM2",mmpi2);
		PlayerPrefs.SetInt ("MMPNUM3",mmpi3);
		PlayerPrefs.SetInt ("MMPNUM4",mmpi4);

		PlayerPrefs.SetInt ("CHHP1",HPC1);
		PlayerPrefs.SetInt ("CHHP2",HPC2);
		PlayerPrefs.SetInt ("CHHP3",HPC3);
		PlayerPrefs.SetInt ("CHHP4",HPC4);
		PlayerPrefs.SetInt ("CHMP1",MPC1);
		PlayerPrefs.SetInt ("CHMP2",MPC2);
		PlayerPrefs.SetInt ("CHMP3",MPC3);
		PlayerPrefs.SetInt ("CHMP4",MPC4);
		PlayerPrefs.Save ();
	}

	public void LoadItems(){
		hpi1 = PlayerPrefs.GetInt("HPINUM",0);
		hpi2 = PlayerPrefs.GetInt("HPINUM2",0);
		hpi3 = PlayerPrefs.GetInt("HPINUM3",0);
		hpi4 = PlayerPrefs.GetInt("HPINUM4",0);
		mpi1 = PlayerPrefs.GetInt("MPINUM",0);
		mpi2 = PlayerPrefs.GetInt("MPINUM2",0);
		mpi3 = PlayerPrefs.GetInt("MPINUM3",0);
		mpi4 = PlayerPrefs.GetInt("MPINUM4",0);

		mhpi1 = PlayerPrefs.GetInt ("MHPNUM",3);
		mhpi2 = PlayerPrefs.GetInt ("MHPNUM2",1);
		mhpi3 = PlayerPrefs.GetInt ("MHPNUM3",1);
		mhpi4 = PlayerPrefs.GetInt ("MHPNUM4",0);
		mmpi1 = PlayerPrefs.GetInt ("MMPNUM",3);
		mmpi2 = PlayerPrefs.GetInt ("MMPNUM2",1);
		mmpi3 = PlayerPrefs.GetInt ("MMPNUM3",1);
		mmpi4 = PlayerPrefs.GetInt ("MMPNUM4",0);

		HPC1 = PlayerPrefs.GetInt ("CHHP1",0);
		HPC2 = PlayerPrefs.GetInt ("CHHP2",0);
		HPC3 = PlayerPrefs.GetInt ("CHHP3",0);
		HPC4 = PlayerPrefs.GetInt ("CHHP4",0);
		MPC1 = PlayerPrefs.GetInt ("CHMP1",0);
		MPC1 = PlayerPrefs.GetInt ("CHMP1",0);
		MPC1 = PlayerPrefs.GetInt ("CHMP1",0);
		MPC1 = PlayerPrefs.GetInt ("CHMP1",0);
	}

	public void ItemGet(){
		PlayerPrefs.SetInt ("MHPNUM",mhpi1);
		PlayerPrefs.SetInt ("MHPNUM2",mhpi2);
		PlayerPrefs.SetInt ("MHPNUM3",mhpi3);
		PlayerPrefs.SetInt ("MHPNUM4",mhpi4);
		PlayerPrefs.SetInt ("MMPNUM",mmpi1);
		PlayerPrefs.SetInt ("MMPNUM2",mmpi2);
		PlayerPrefs.SetInt ("MMPNUM3",mmpi3);
		PlayerPrefs.SetInt ("MMPNUM4",mmpi4);
		PlayerPrefs.Save ();
	}

	public void ItemLoad(){
		mhpi1 = PlayerPrefs.GetInt ("MHPNUM",3);
		mhpi2 = PlayerPrefs.GetInt ("MHPNUM2",1);
		mhpi3 = PlayerPrefs.GetInt ("MHPNUM3",1);
		mhpi4 = PlayerPrefs.GetInt ("MHPNUM4",0);
		mmpi1 = PlayerPrefs.GetInt ("MMPNUM",3);
		mmpi2 = PlayerPrefs.GetInt ("MMPNUM2",1);
		mmpi3 = PlayerPrefs.GetInt ("MMPNUM3",1);
		mmpi4 = PlayerPrefs.GetInt ("MMPNUM4",0);
	}
}
