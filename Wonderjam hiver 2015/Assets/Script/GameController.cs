using UnityEngine;
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
	// Use this for initialization
	void Start () {
		jInterface.SetActive (false);
		int i =	GameObject.FindWithTag("PlateformManager").GetComponent<PlatformManager>().numberOfObjects;
		timer = timer + i*coef;
		GetComponent<TimerGUI>().initTimer();
	}


	public void Win(){
		win=true;
		audio.Play();
		//play victory animation
		//load next level
		Invoke ("restart",5);
		Application.LoadLevel(Application.loadedLevel);
	}
	void restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	void GameOver(){
		//Application.LoadLevel(Application.loadedLevel);
		timeOver = Time.time + timer;
		player.rigidbody2D.position = playerSpawn;
		player.rigidbody2D.rotation = 0.0f;
		GameObject.FindWithTag("Exit").GetComponent<GoalControl>().openDoor();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P))
			Application.LoadLevel(Application.loadedLevel);
		if (Input.GetKeyDown(KeyCode.L)&&!playerspawnned){
			spawnPlayer();
		}
        if (Time.time > timeOver&&!gameOver&&!win&&!beginGame) {
            gameOver = true;
			GameObject.FindWithTag("Exit").GetComponent<GoalControl>().closeDoor();
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
			timeOver = Time.time + timer;
			beginGame = true;
			GetComponent<TimerGUI> ().beginCountdown ();
			GameObject toKill = GameObject.FindWithTag ("TowerBuild");
			//Instantiate (uij1, toKill.transform.position, toKill.transform.rotation);
			Destroy (toKill);
			jInterface.SetActive (true);
		}
	}
}

