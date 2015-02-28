
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movingtower : MonoBehaviour {
	public bool ready;
	public GameObject gamecontroller;
	public GameObject me;
	public Button readyButton;
	public TowerMasterList zeList;

	void Start () {
		ready = false;
		zeList = gamecontroller.GetComponent<TowerMasterList>();
		zeList.addMasterList(me);
	}

	void Update () {
		
		
		if (ready) {
			if (Input.GetMouseButton (1)) {

					//Si il y a déja un élément de la liste de pret
					Vector3 pos = Input.mousePosition;
					pos.z = Camera.main.transform.position.z;
					
					pos = Camera.main.ScreenToWorldPoint (pos);
					transform.position = Vector2.Lerp (transform.position, pos, 0.9f);

			}
		}
	}

	public void changeReady () { 
		if (zeList.checkMasterList() || ready)
		{
			ready = !ready; 
			if (ready)
				readyButton.GetComponent<Image> ().color = Color.red;
			else
				readyButton.GetComponent<Image> ().color = Color.white;
		} else
			Debug.Log ("Il existe deja un element qui se deplace");
	}
}
