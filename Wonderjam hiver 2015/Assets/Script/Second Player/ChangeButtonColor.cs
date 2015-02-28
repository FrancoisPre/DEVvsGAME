using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeButtonColor : MonoBehaviour {
	bool isRed;
	// Use this for initialization
	void Start () {
		isRed = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void changeRed() {

		if (!isRed) {
			GetComponent<Image> ().color = Color.red;
			isRed = !isRed;
		} else {
			GetComponent<Image> ().color = Color.white;
			isRed = !isRed;
		}
	}
}
