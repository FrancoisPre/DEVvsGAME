using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Tower") {
			if(other.tag == "Player")
				other.GetComponent<PlayerController>().pushHard();
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			audio.Play();
			Destroy (gameObject);
		}
	}
}
