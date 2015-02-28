
using UnityEngine;
using System.Collections;

public class Movingtower : MonoBehaviour {
	public bool ready;

	// Use this for initialization
	void Start () {
		ready = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (ready) {
			if (Input.GetMouseButton (1)) {
				Debug.Log ("Held");
				
				Vector3 pos = Input.mousePosition;
				//pos.z = 1;
				pos.z = Camera.main.transform.position.z;
				
				pos = Camera.main.ScreenToWorldPoint (pos);
				Debug.Log (pos);
				pos.x = Camera.main.transform.position.x - pos.x;
				
				//Le 8 ici risque d'avoir besoin d'etre changé, il varie selon la caméra
				pos.y = 6 + Camera.main.transform.position.y - pos.y;
				transform.position = Vector2.Lerp (transform.position, pos, 0.9f);
				
			} else {
				Debug.Log ("Not held");
			}
		}
	}

	public void changeReady () { 
		ready = !ready; 
		
		
	}
}
