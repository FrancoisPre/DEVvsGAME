using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	private bool open=true;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag==("Player")&&open){
			GameObject.FindWithTag("GameController").GetComponent<GameController>().Win();
		}
	}

	public void close(){
		open=false;
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
