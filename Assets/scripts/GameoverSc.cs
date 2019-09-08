using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverSc : MonoBehaviour {

	public Button Gtitle;
	public Button res;

	// Use this for initialization
	void Start () {
		Gtitle.onClick.AddListener (gtitle);
		res.onClick.AddListener (Restart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gtitle(){
		StatusManager.instance.hprecovery ();
		SceneManager.LoadScene ("Title");
	}

	public void Restart(){
		StatusManager.instance.hprecovery ();
		SceneManager.LoadScene ("Main");
	}
}
