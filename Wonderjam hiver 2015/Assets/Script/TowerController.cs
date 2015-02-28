using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	public bool PlayerDetected;
	public float Firerate;
	public float Timer;
	public GameObject boolet;
	public Transform spawn;
	public Transform playerposition;

	// Use this for initialization
	void Start () {
		PlayerDetected = false;
		Firerate = .5f;

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerDetected && Timer >= Firerate)
			ShootToKill ();
		if(PlayerDetected)
			Timer += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			PlayerDetected = true;
			
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			PlayerDetected = false;
		
	}

	void ShootToKill(){
		Instantiate (boolet, spawn.position, spawn.rotation);
		Timer = 0.0f;
		audio.Play();
	}
}