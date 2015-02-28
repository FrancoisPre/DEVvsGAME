using UnityEngine;
using System.Collections;

public class Movingtower : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetMouseButton(0)){
			Debug.Log("Held");

			Vector3 pos = Input.mousePosition;
			pos = Camera.main.ScreenToWorldPoint(pos);

			Debug.Log(pos);
			transform.position = pos;
			//			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

		}
		else{
			Debug.Log("Not held");
		}


		

	}
}
