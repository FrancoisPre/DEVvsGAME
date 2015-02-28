using UnityEngine;
using System.Collections;

public class ChangeReady : MonoBehaviour {

	public GameObject towerObject;
	public Movingtower tower;
	// Use this for initialization
	void Start () {
		tower = towerObject.GetComponent<Movingtower> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void changeReady () { 
		tower.ready = false; 

	
	}
}
