using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class TimerGUI : MonoBehaviour {

	public Text countdown;
	private int countdownTimer;
	private bool count=false;



	// Use this for initialization
	void Start () {
		GameController gameController = GetComponent<GameController> ();
		countdownTimer = (int) (gameController.timer* 100.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (count){
			countdownTimer -=  (int) ((Time.deltaTime)*100.0f);
			if (countdownTimer < 0) {
				countdownTimer=0;
			}
			//Debug.Log (countdownTimer);
			int minutes = countdownTimer / (60 * 100);
			int secondes = (countdownTimer % (60 * 100)) / 100;
			int centaines = countdownTimer % 100;
			countdown.text = minutes + ":" + secondes + ":" + centaines;
		}
	}
	public void beginCountdown(){
		count = true;
	}
}
