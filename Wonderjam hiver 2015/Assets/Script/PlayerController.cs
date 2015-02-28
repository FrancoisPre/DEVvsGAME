using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float movement;
    private Vector2 deplacement;
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    public bool jumpable = false;
    public float minJump;
	public bool invertCmd = false;
    private float jumpComponnent;
	public float debCurse;

	// Use this for initialization
	void Start () {
		GameObject gc = GameObject.FindWithTag("GameController");
		GameController gC = gc.GetComponent<GameController>();
		gC.PlayerRegistration(gameObject);
	}

   

	// Update is called once per frame
	void FixedUpdate () {
		if (rigidbody2D.position.y<(-100)){
			rigidbody2D.position = new Vector3(0.0f,0.0f,0.0f);
			rigidbody2D.velocity = new Vector2(0.0f,0.0f);
		}
		else{
	        movement = Input.GetAxis("Horizontal");
	        deplacement = rigidbody2D.velocity;
	        if (Mathf.Abs(deplacement.y) < minJump)
	            jumpable = true;
	        else
	            jumpable = false;

			if (invertCmd)
				if (debCurse + 5 < Time.time)
							invertCmd = false;
						else
							movement = -movement;
	        if (Input.GetButtonDown("Jump") && jumpable)
	            jumpComponnent = jumpSpeed;
	        else
	            jumpComponnent = 0.0f;
	       
	        rigidbody2D.AddForce(Time.deltaTime * speed * new Vector2(movement,jumpComponnent));
		}
	}
}
