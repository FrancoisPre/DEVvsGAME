using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float timer;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, timer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
