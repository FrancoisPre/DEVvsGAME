using UnityEngine;
using System.Collections;

public class TowerMasterList : MonoBehaviour {

	GameObject[] towers;
	Movingtower testatt;

	// Use this for initialization
	void Start () {
		//towers [1] = test;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool checkMasterList () {
		for (int i = 0; i<towers.Length; i++) {
			testatt = towers[i].GetComponent<Movingtower>();
			//Renvoie true si une des towers est déja ready
			if (testatt.ready)
				return false;
		}

		return true;
	}

	public void addMasterList (GameObject newTower) {
		Debug.Log ("Adding element to #" + (towers.Length + 1));
		towers [towers.Length + 1] = newTower;
	}
}
