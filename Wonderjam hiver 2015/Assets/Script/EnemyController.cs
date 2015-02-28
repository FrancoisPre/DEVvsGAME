using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour {

	public float speed;
	public float rayCastSide;


	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (1, 0);
		rigidbody2D.velocity = rigidbody2D.velocity * speed;
	}
	
	// Update is called once per frame
	void Update () {


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
		hitLeft = Physics2D.Raycast (rigidbody2D.position, leftOffset.normalized, leftOffset.sqrMagnitude);




		
		// SI LE RAYCAST GAUCHE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if (hitLeft.collider == null) 
		{
			Debug.Log ("rien a gauche");
			rigidbody2D.velocity= rigidbody2D.velocity*(-1.0f);
		}

		//On vérifie en bas a droite de l'enemi
		Vector2 rightRayCastPosition = new Vector2 (rigidbody2D.position.x + rayCastSide, rigidbody2D.position.y - rayCastSide);
		var rightOffset = rightRayCastPosition - rigidbody2D.position;
		hitRight = Physics2D.Raycast(rigidbody2D.position, rightOffset.normalized, rightOffset.sqrMagnitude);

		// SI LE RAYCAST DROITE N'ENTRE PAS EN COLLISION AVEC UNE PLATEFORME
		if (hitRight.collider == null)
		{
			Debug.Log ("rien a droite");
			rigidbody2D.velocity=rigidbody2D.velocity*(-1.0f);
		}


	}
	
}
