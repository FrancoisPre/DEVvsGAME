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
	}

	// Update is called once per frame
	void Update () {
        if (Time.time > timeOver&&!gameOver) {
            gameOver = true;
			GameObject.FindWithTag("Exit").GetComponent<GoalControl>().close();
        }
		if (player!=null){
			Camera.main.transform.position = new Vector3(player.transform.position.x ,player.transform.position.y ,Camera.main.transform.position.z);
		}
	}
}
