using UnityEngine;
using System.Collections;

public class ROTATOR : MonoBehaviour {

	public Transform playerposition;


	// Use this for initialization
	void Start () {
		playerposition = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(Vector3.forward, (transform.position - playerposition.position + transform.rotation));
	}
}
