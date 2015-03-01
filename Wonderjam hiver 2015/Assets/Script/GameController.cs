using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public float timer;
    private float timeOver;
    private bool gameOver = false;
	public GameObject player;
	private GameObject playerInstance;
	private bool win;
	public Vector3 playerSpawn;
	public bool beginGame=false;
	public GameObject jInterface;
	private bool playerspawnned=false;
	public int coef;
	private GameObject door;
	private bool flipper = false;
	public Button wookieflip;
	// Use this for initialization
	void Start () {
		jInterface.SetActive (false);
		int i =	GameObject.FindWithTag("PlateformManager").GetComponent<PlatformManager>().numberOfObjects;
		timer = timer + i*coef;
		GetComponent<TimerGUI>().initTimer((int)Mathf.Floor(timer));
	}


	public void Win(){
		door = GameObject.FindWithTag ("Exit");
		win=true;
		audio.Play();
		//play victory animation
		//load next level
		playerInstance.GetComponent<PlayerController>().gameOver();
		Invoke ("restart",11);
		GetComponent<TimerGUI> ().playerWon ();
		//Application.LoadLevel(Application.loadedLevel);

		Destroy (door);
	}

	void restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	void GameOver(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public int getTimer(){
		return (int)Mathf.Floor (timeOver - Time.time);
	}


	public void flipWook(){
		flipper = !flipper;
		
		if (flipper)
			wookieflip.GetComponent<Image> ().color = Color.red;
		else
			wookieflip.GetComponent<Image> ().color = Color.white;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.P))
			Application.LoadLevel(Application.loadedLevel);
		if (Input.GetKeyDown(KeyCode.L)&&!playerspawnned){
			spawnPlayer();
		}
        if (Time.time > timeOver&&!gameOver&&!win&&beginGame) {
			Debug.Log (Time.time);
            gameOver = true;
			GameObject.FindWithTag("Exit").GetComponent<GoalControl>().closeDoor();
			PlayerController tmp =playerInstance.GetComponent<PlayerController>();
			tmp.gameOver();
			GameObject.FindWithTag("Ending").audio.Play();
			Invoke("GameOver",5);
        }
		if (playerInstance!=null){
			Camera.main.transform.position = new Vector3(playerInstance.transform.position.x ,playerInstance.transform.position.y ,Camera.main.transform.position.z);
		}
	}

	public void spawnPlayer(){
		if (!playerspawnned){
			playerspawnned = true;
			playerInstance = (GameObject)Instantiate(player,playerSpawn,Quaternion.identity);
			playerInstance.rigidbody2D.fixedAngle = !flipper;
			timeOver = Time.time + timer;
			beginGame = true;
			GetComponent<TimerGUI> ().beginCountdown();
			GameObject toKill = GameObject.FindWithTag ("TowerBuild");
			Destroy (toKill);
			jInterface.SetActive (true);
		}
	}
}

