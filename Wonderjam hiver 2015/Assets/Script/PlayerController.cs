using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float movement;
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
	public float hardPush;
	public float softPush;
	public float curseTime;
	private bool doubleJump=false;
	public float maxSpeed;
	public float raycastlenght;

	//Variables d'initialisation (Mode tower -> Mode platformer)
	public bool playerReady;

	// Use this for initialization
	void Start () {
		layermask= (1<<layerNumber);
		//playerReady = false;
		playerReady = true;

	}

	void OnDrawGizmos(){
		Gizmos.DrawLine(rigidbody2D.position, rigidbody2D.position  + new Vector2(0.0f,-mindistjump));
	}
   

	public void pushHard(Vector3 direction){
		Vector3 d = direction.normalized;
		rigidbody2D.AddForce(d*hardPush);
	}

	public void pushSoft(Vector3 direction){
		Vector3 d = direction.normalized;
		rigidbody2D.AddForce(d*softPush);
	}

	public void changeReady() {
		playerReady = !playerReady;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (rigidbody2D.position.y<(-100)){
			rigidbody2D.position = new Vector3(5.0f,5.0f,0.0f);
			rigidbody2D.velocity = new Vector2(0.0f,0.0f);
			rigidbody2D.rotation = 0.0f;
		}
		else{
			RaycastHit2D hit;
			Vector2 rayCastPosition = new Vector2(rigidbody2D.position.x,rigidbody2D.position.y-raycastlenght);
			Vector2 offset = rayCastPosition - rigidbody2D.position;
			hit = Physics2D.Raycast(rigidbody2D.position,offset.normalized,offset.sqrMagnitude,layermask);
			float tmp = hit.distance;
			//Debug.Log(tmp);
			if (tmp!=0 && tmp<mindistjump){
				jumpable=true;
				doubleJump=true;
			}
			else
				jumpable=false;


	        movement = Input.GetAxis("Horizontal");
			/*				if (curseTime >= )
					invertCmd = false;
				else
					movement = -movement;*/
	   		if (invertCmd) 
				movement = -movement;

			if (Input.GetButtonDown ("Jump") && jumpable){
				jumpComponnent = jumpSpeed;
				audio.Play();
				//doubleJump=true;
			}
			else if (doubleJump&&Input.GetButtonDown("Jump")){
				jumpComponnent = jumpSpeed;
				doubleJump=false;
				audio.Play();
			}
			else
				jumpComponnent = 0.0f;
	       
			if (!invertCmd)
				rigidbody2D.AddForce (Time.deltaTime * speed * new Vector2 (movement, jumpComponnent));
			else
				rigidbody2D.AddForce (Time.deltaTime * -speed * new Vector2 (-movement, -jumpComponnent));
			Vector2 vitesse = rigidbody2D.velocity;
			vitesse.x =Mathf.Clamp(vitesse.x, -maxSpeed, maxSpeed);
			rigidbody2D.velocity=vitesse;
			}
		}
	}

