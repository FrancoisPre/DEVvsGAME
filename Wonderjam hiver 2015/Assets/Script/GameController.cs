using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float timer;
    private float timeOver;
    private bool gameOver = false;
	private GameObject player;
	// Use this for initialization
	void Start () {
        timeOver = Time.time + timer;
	}

	public void PlayerRegistration (GameObject _player) {
		player=_player;
	}

	// Update is called once per frame
	void Update () {
        if (Time.time > timeOver) {
            gameOver = true;
        }
		if (player!=null){
			Camera.main.transform.position = new Vector3(player.transform.position.x + 15.0f,player.transform.position.y + 5.0f,Camera.main.transform.position.z);
		}
	}
}
