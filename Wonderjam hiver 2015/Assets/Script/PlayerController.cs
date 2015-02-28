using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float movement;
    private Vector2 deplacement;
    public float speed;
    public float jumpSpeed;
    public bool jumpable = false;
    public float minJump;
	public bool invertCmd = false;
    private float jumpComponnent;
	public float debCurse;
	public float mindistjump;
	private int layermask;
	public int layerNumber;
	public Vector2 hardPush;
	public Vector2 softPush;
	public float curseTime;
	private bool doubleJump=false;

	//Variables d'initialisation (Mode tower -> Mode platformer)
	public bool playerReady;

	// Use this for initialization
	void Start () {
		GameObject gc = GameObject.FindWithTag("GameController");
		GameController gC = gc.GetComponent<GameController>();
		gC.PlayerRegistration(gameObject);
		layermask= (1<<layerNumber);
		//playerReady = false;

	}

	void OnDrawGizmos(){
		Gizmos.DrawLine(rigidbody2D.position, rigidbody2D.position  + new Vector2(0.0f,-mindistjump));
	}
   

	public void pushHard(){
		rigidbody2D.AddRelativeForce(hardPush);
	}

	public void pushSoft(){
		rigidbody2D.AddRelativeForce(softPush);
	}

	public void changeReady() {
		playerReady = !playerReady;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (rigidbody2D.position.y<(-100)){
			rigidbody2D.position = new Vector3(5.0f,0.0f,0.0f);
			rigidbody2D.velocity = new Vector2(0.0f,0.0f);
			rigidbody2D.rotation = 0.0f;
		}
		else{
			RaycastHit2D hit;
			Vector2 rayCastPosition = new Vector2(rigidbody2D.position.x,rigidbody2D.position.y-1);
			Vector2 offset = rayCastPosition - rigidbody2D.position;
			hit = Physics2D.Raycast(rigidbody2D.position,offset.normalized,offset.sqrMagnitude,layermask);
			float tmp = hit.distance;
			Debug.Log(tmp);
			if (tmp!=0 && tmp<mindistjump)
				jumpable=true;
			else
				jumpable=false;
	        movement = Input.GetAxis("Horizontal");
	        deplacement = rigidbody2D.velocity;
	   		if (invertCmd)
				if (debCurse + curseTime < Time.time)
					invertCmd = false;
				else
					movement = -movement;
				if (Input.GetButtonDown ("Jump") && jumpable){
					jumpComponnent = jumpSpeed;
					doubleJump=true;
				}
				else if (doubleJump&&Input.GetButtonDown("Jump")){
					jumpComponnent = jumpSpeed;
					doubleJump=false;
				}
				else
					jumpComponnent = 0.0f;
		       
				rigidbody2D.AddForce (Time.deltaTime * speed * new Vector2 (movement, jumpComponnent));
			}
		}
	}

