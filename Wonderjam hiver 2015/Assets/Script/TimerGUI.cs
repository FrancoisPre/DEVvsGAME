using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class TimerGUI : MonoBehaviour {

	public Text countdown;
	private int countdownTimer;
	private bool count=false;
	private GameController gameController;
	private bool playerW=false;


	// Use this for initialization
	void Start () {
		gameController = GetComponent<GameController> ();
	}

	public void initTimer(int timer){
		countdownTimer = timer*100;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (count){
			countdownTimer =  gameController.getTimer()*100;
			if (countdownTimer < 0 || playerW) {
				countdownTimer=0;
				countdown.text = "Game Over";
			}
			else {
				//Debug.Log (countdownTimer);
				int minutes = countdownTimer / (60 * 100);
				int secondes = (countdownTimer % (60 * 100)) / 100;
				int centaines = countdownTimer % 100;
				countdown.text = minutes + ":" + secondes + ":" + Random.Range(0,1000);
			}
		}
	}

	public void playerWon(){
		playerW = true;
	}

	public void beginCountdown(){
		count = true;
		Debug.Log ("Let's Begin Biatch");
		Debug.Log (countdownTimer);
	}
}
