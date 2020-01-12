using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameoverSc : MonoBehaviour {

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
