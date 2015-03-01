using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float speed;
	public float rayCastSide;//ICI JE CRÉE LES LAYERS NÉCESSAIRES AFIN D'ÉVITER QUE L'ENEMY PARTE DE LA PLATEFORME
	public float horizontalCastSide;
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
		
		Gizmos.DrawLine (new Vector3 (leftRayCastPosition.x, leftRayCastPosition.y, 0), new Vector3 (rigidbody2D.position.x, rigidbody2D.position.y, 0));
		
		Vector2 rightRayCastPosition = new Vector2 (rigidbody2D.position.x + rayCastSide, rigidbody2D.position.y - rayCastSide);
		
		Gizmos.DrawLine (new Vector3 (rightRayCastPosition.x, rightRayCastPosition.y, 0), new Vector3 (rigidbody2D.position.x, rigidbody2D.position.y, 0));

		Vector2 leftHorizontalCastPosition = new Vector2 (rigidbody2D.position.x - horizontalCastSide, rigidbody2D.position.y);
		Gizmos.DrawLine (new Vector3 (leftHorizontalCastPosition.x, leftHorizontalCastPosition.y, 0), new Vector3 (rigidbody2D.position.x, rigidbody2D.position.y, 0));

		Vector2  rightHorizontalCastPosition = new Vector2 (rigidbody2D.position.x + horizontalCastSide, rigidbody2D.position.y);
		Gizmos.DrawLine (new Vector3(rightHorizontalCastPosition.x,rightHorizontalCastPosition.y,0), new Vector3(rigidbody2D.position.x,rigidbody2D.position.y,0));
	}
	void FixedUpdate(){
		RaycastHit2D hitLeft;
		RaycastHit2D hitRight;
		RaycastHit2D hitHorizontalLeft;
		RaycastHit2D hitHorizontalRight;
		
		
		
		
		//On vérifie en bas a gauche de l'ennemi
		Vector2 leftRayCastPosition = new Vector2 (rigidbody2D.position.x - rayCastSide, rigidbody2D.position.y - rayCastSide);
		var leftOffset = leftRayCastPosition - rigidbody2D.position;
		hitLeft = Physics2D.Raycast (rigidbody2D.position, leftOffset.normalized, leftOffset.sqrMagnitude, finalMask);

		//On vérifie en bas a droite de l'enemi
		Vector2 rightRayCastPosition = new Vector2 (rigidbody2D.position.x + rayCastSide, rigidbody2D.position.y - rayCastSide);
		var rightOffset = rightRayCastPosition - rigidbody2D.position;
		hitRight = Physics2D.Raycast(rigidbody2D.position, rightOffset.normalized, rightOffset.sqrMagnitude, finalMask);
		


		//LES HORIZONTALES RAYCAST


		if (rigidbody2D.velocity.x < 0 && (int) rigidbody2D.velocity.y==0) {
			Vector2  leftHorizontalCastPosition = new Vector2 (rigidbody2D.position.x - horizontalCastSide, rigidbody2D.position.y);
			Debug.Log (leftHorizontalCastPosition);
			Vector2 leftHorizontalOffset = leftHorizontalCastPosition - rigidbody2D.position;
			Debug.Log (leftHorizontalOffset);
			hitHorizontalLeft = Physics2D.Raycast (rigidbody2D.position, leftHorizontalOffset.normalized, leftHorizontalOffset.sqrMagnitude, finalMask);

			if (hitHorizontalLeft.collider != null) {
				Debug.Log("TAPPE PLATEFORME A L' HORIZONTALE VERS GAUCHE");
				rigidbody2D.velocity = rigidbody2D.velocity * (-1.0f);
			}
		} 


		else if(rigidbody2D.velocity.x>=0 &&(int)rigidbody2D.velocity.y==0)
		{
			Vector2  rightHorizontalCast = new Vector2 (rigidbody2D.position.x + horizontalCastSide, rigidbody2D.position.y);
			Debug.Log (rightHorizontalCast);
			Vector2 rightHorizontalOffset = rightHorizontalCast - rigidbody2D.position;
			Debug.Log (rightHorizontalOffset);
			hitHorizontalRight = Physics2D.Raycast (rigidbody2D.position, rightHorizontalOffset.normalized, rightHorizontalOffset.sqrMagnitude, finalMask);

			if (hitHorizontalRight.collider != null) {
				Debug.Log("TAPPE PLATEFORME A L' HORIZONTALE VERS DROTIE");
				rigidbody2D.velocity = rigidbody2D.velocity * (-1.0f);
			}
		}



		// SI LE RAYCAST GAUCHE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if ((hitLeft.collider == null) ) {
			Debug.Log ("rien a gauche");
			rigidbody2D.velocity = rigidbody2D.velocity * (-1.0f);
		}
		// SI LE RAYCAST DROITE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if ((hitRight.collider == null)) {
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

