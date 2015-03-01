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
					player.invertCmd = !player.invertCmd;
					fuckthatscript = true;
					audio.Play ();
				}
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
}

