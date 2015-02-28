using UnityEngine;
using System.Collections;

public class BooletMover : MonoBehaviour {

	public float speed;
	public Transform playerposition;
	public Vector2 direction;

	// Use this for initialization
	void Start () {
		playerposition = GameObject.FindGameObjectWithTag ("Player").transform;
		direction = new Vector2(((playerposition.position.x)-transform.position.x),((playerposition.position.y)-transform.position.y));
		rigidbody2D.velocity = direction*speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
