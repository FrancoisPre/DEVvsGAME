
using UnityEngine;
using System.Collections;

public class Movingtower : MonoBehaviour {
	public bool ready;

	void Start () {
		ready = false;
		
	}

	void Update () {
		
		
		if (ready) {
			if (Input.GetMouseButton (1)) {
				
				Vector3 pos = Input.mousePosition;
				pos.z = Camera.main.transform.position.z;
				
				pos = Camera.main.ScreenToWorldPoint (pos);
				pos.x = Camera.main.transform.position.x - pos.x;
				
				//Le 8 ici risque d'avoir besoin d'etre changé, il varie selon la caméra
				pos.y = 6 + Camera.main.transform.position.y - pos.y;
				transform.position = Vector2.Lerp (transform.position, pos, 0.9f);

			}
		}
	}

	public void changeReady () { 
		ready = !ready; 
		
		
	}
}
