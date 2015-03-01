using UnityEngine;
using System.Collections;

public class Fear : MonoBehaviour
{
	private bool fuckthatscript = false;
	void OnTriggerEnter2D (Collider2D other)
	{
		if (!fuckthatscript) {
			if (other.tag == "Player") {
				PlayerController player = (PlayerController)other.GetComponent ("PlayerController");
				if (player.invertCmd == false) {
					player.invertCmd = true;
				} else
					player.invertCmd = false;

				fuckthatscript = true;
				audio.Play ();
				GameObject mustDie = transform.GetChild(1).gameObject;
				DestroyObject(mustDie);
				//Destroy
				//Invoke ("suicide", 3.0f);
			}
		}
	}

	/*void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerController player = (PlayerController)other.GetComponent ("PlayerController");
			player.debCurse = Time.time;
		}
	}*/

	void suicide() {
		Destroy (gameObject);
	}
}

