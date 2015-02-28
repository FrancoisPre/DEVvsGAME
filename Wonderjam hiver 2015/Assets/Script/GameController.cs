using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float timer;
    private float timeOver;
    private bool gameOver = false;
	// Use this for initialization
	void Start () {
        timeOver = Time.time + timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeOver) {
            gameOver = true;
        }
	}
}
