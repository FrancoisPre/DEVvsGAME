using UnityEngine;
using System.Collections;

public class Fear : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerController player = (PlayerController)other.GetComponent ("PlayerController");
			player.invertCmd = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerController player = (PlayerController)other.GetComponent ("PlayerController");
			player.debCurse = Time.time;
		}
	}
}

