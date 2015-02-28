using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float timer;
    private float timeOver;
    private bool gameOver = false;
	private GameObject player;
	private bool win;
	// Use this for initialization
	void Start () {
        timeOver = Time.time + timer;
	}

	public void PlayerRegistration (GameObject _player) {
		player=_player;
	}

	public void Win(){
		win=true;
		//play victory animation
		//load next level
	}

	void GameOver(){
		Application.LoadLevel(Application.loadedLevel);
	}

	// Update is called once per frame
	void Update () {
        if (Time.time > timeOver&&!gameOver&&!win) {
            gameOver = true;
			GameObject.FindWithTag("Exit").GetComponent<GoalControl>().close();
			Invoke("GameOver",5);
        }
		if (player!=null){
			Camera.main.transform.position = new Vector3(player.transform.position.x ,player.transform.position.y ,Camera.main.transform.position.z);
		}
	}
}
