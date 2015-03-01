using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerMasterList : MonoBehaviour {

	List<GameObject> towers = new List<GameObject> ();
	Movingtower testatt;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool checkMasterList () {
		for (int i = 0; i<towers.Count; i++) {
			testatt = towers[i].GetComponent<Movingtower>();
			//Renvoie true si une des towers est déja ready

			if (testatt.ready)
				//Debug.Log ("La tour #" + i + " est ready, on renvoie false");
				return false;
		}

		return true;
	}

	public void addMasterList (GameObject newTower) {
		Debug.Log ("Adding element to #" + (towers.Count + 1));
		towers.Add (newTower);
		//Debug.Log ("Adding element to #" + (towers.Length));
		//towers [towers.Length + 1] = newTower;
	}

	public void changeReady() {
		for (int i = 0; i<towers.Count; i++) {
			testatt = towers [i].GetComponent<Movingtower> ();
			
			if (testatt.ready)
				testatt.changeReady ();
		}
	}
}
