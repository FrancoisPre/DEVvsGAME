using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float speed;
	public float rayCastSide;//ICI JE CRÉE LES LAYERS NÉCESSAIRES AFIN D'ÉVITER QUE L'ENEMY PARTE DE LA PLATEFORME
	public int maskPlatform; //INDICE DU LAYER 
	private Vector2 velocity;
	private bool isSnap=false;
	
	
	private int finalMask;
	
	
	// Use this for initialization
	void Start () {
		finalMask = (1 << maskPlatform);

	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void onTriggerEnter2D(Collider2D other){
		if (other.tag=="Player"){
			other.GetComponent<PlayerController>().pushSoft(rigidbody2D.velocity);
		}
	}

	void OnDrawGizmos()
	{
		Vector2 leftRayCastPosition = new Vector2 (rigidbody2D.position.x - rayCastSide, rigidbody2D.position.y - rayCastSide);
		
		Gizmos.DrawLine (new Vector3(leftRayCastPosition.x,leftRayCastPosition.y,0), new Vector3(rigidbody2D.position.x,rigidbody2D.position.y,0));
		
		Vector2 rightRayCastPosition = new Vector2 (rigidbody2D.position.x + rayCastSide, rigidbody2D.position.y - rayCastSide);
		
		Gizmos.DrawLine (new Vector3(rightRayCastPosition.x,rightRayCastPosition.y,0), new Vector3(rigidbody2D.position.x,rigidbody2D.position.y,0));
	}
	
	void FixedUpdate(){
		RaycastHit2D hitLeft;
		RaycastHit2D hitRight;
		
		
		
		
		//On vérifie en bas a gauche de l'ennemi
		Vector2 leftRayCastPosition = new Vector2 (rigidbody2D.position.x - rayCastSide, rigidbody2D.position.y - rayCastSide);
		var leftOffset = leftRayCastPosition - rigidbody2D.position;
		hitLeft = Physics2D.Raycast (rigidbody2D.position, leftOffset.normalized, leftOffset.sqrMagnitude, finalMask);
		//On vérifie en bas a droite de l'enemi
		Vector2 rightRayCastPosition = new Vector2 (rigidbody2D.position.x + rayCastSide, rigidbody2D.position.y - rayCastSide);
		var rightOffset = rightRayCastPosition - rigidbody2D.position;
		hitRight = Physics2D.Raycast(rigidbody2D.position, rightOffset.normalized, rightOffset.sqrMagnitude, finalMask);
		
		
		
		
		// SI LE RAYCAST GAUCHE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if (hitLeft.collider == null) {
			Debug.Log ("rien a gauche");
			rigidbody2D.velocity = rigidbody2D.velocity * (-1.0f);
		}
		// SI LE RAYCAST DROITE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if (hitRight.collider == null) {
			Debug.Log ("rien a droite");
			rigidbody2D.velocity = rigidbody2D.velocity * (-1.0f);
		}
		if (hitRight.collider == null && hitLeft.collider == null) {
			rigidbody2D.velocity = new Vector2 (0, -1) * speed;
			isSnap=false;

		} else if(!isSnap){
			isSnap =true;
			if (Random.value > 0.5f) {
				velocity = speed * new Vector2 (1, 0);
			} else {
				velocity = speed * new Vector2 (-1,0);
			}
			rigidbody2D.velocity = velocity;

		}


		/*
		if (rigidbody2D.velocity.x < 0) {
			rigidbody2D.velocity= velocity*(-1);
		}
		else {
			rigidbody2D.velocity= velocity*(1);
		}*/


	}




}

