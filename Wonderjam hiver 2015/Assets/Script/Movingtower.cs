
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
			//pos.z = 1;
			pos.z = Camera.main.transform.position.z;
			
			pos = Camera.main.ScreenToWorldPoint(pos);
			Debug.Log(pos);
			pos.x = Camera.main.transform.position.x-pos.x;
			
			//Le 8 ici risque d'avoir besoin d'etre changé, il varie selon la caméra
			pos.y = 6+Camera.main.transform.position.y-pos.y;
			transform.position = Vector2.Lerp(transform.position, pos, 0.9f);
			
		}
		else{
			Debug.Log("Not held");
		}
		
		
		
		
	}
}
