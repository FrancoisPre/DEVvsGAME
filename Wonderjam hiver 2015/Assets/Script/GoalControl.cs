using UnityEngine;
using System.Collections;

public class GoalControl : MonoBehaviour {
	private bool open=true;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag==("Player")&&open){
			//GetComponentInChildren<SpriteRenderer>().color = Color.green;
			GameObject.FindWithTag("GameController").GetComponent<GameController>().Win();
		}
	}
	
	public void closeDoor(){
		open=false;
		//GetComponentInChildren<SpriteRenderer>().color = Color.white;
	}

	public void openDoor(){
		open = true;
		//GetComponentInChildren<SpriteRenderer> ().color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
