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
	private bool beginGame=false;
	// Use this for initialization
	void Start () {
	}


	public void Win(){
		win=true;
		//play victory animation
		//load next level
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
		if (Input.GetKey(KeyCode.R))
			GameOver();
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
		playerInstance = (GameObject)Instantiate(player,playerSpawn,Quaternion.identity);
		timeOver = Time.time + timer;
		beginGame = true;
		GetComponent<TimerGUI> ().beginCountdown ();
		GameObject toKill = GameObject.FindWithTag ("TowerBuild");
		Destroy (toKill);
	}
}

