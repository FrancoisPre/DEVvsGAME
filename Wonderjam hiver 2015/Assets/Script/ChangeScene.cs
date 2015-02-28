using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string levelName;

	public void LoadLevel(string levelName){

		Application.LoadLevel (levelName);
	}


}
