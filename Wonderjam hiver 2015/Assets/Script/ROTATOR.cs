using UnityEngine;
using System.Collections;

public class ROTATOR : MonoBehaviour {

	public Transform playerposition;

	private TowerController towerController;


	// Use this for initialization
	void Start () {

		towerController = transform.parent.GetComponent<TowerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 point = new Vector3 (playerposition.position.x, playerposition.position.y,0);
		//transform.rotation = Quaternion.LookRotation(Vector3.forward, (transform.position - playerposition.position));
		if (towerController.PlayerDetected) {
			playerposition = GameObject.FindGameObjectWithTag ("Player").transform;
			Vector3 dir = new Vector3 (playerposition.position.x - transform.position.x, playerposition.position.y - transform.position.y, 0) * (-1);
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}
}
