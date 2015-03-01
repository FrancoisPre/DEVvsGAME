using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameController gc;
	public float speed = 25.0f;
	public float cameraDistanceMax = 20f;
	public float cameraDistanceMin = 5f;
	public float cameraDistance = 10f;
	public float scrollSpeed = 9f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!gc.beginGame)
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		}
		if (Input.GetKey (KeyCode.R)) {
			camera.orthographicSize = camera.orthographicSize + 15*Time.deltaTime;
			if(camera.orthographicSize > 120)
			{
				camera.orthographicSize = 120; // Max size
			}
		}
		if (Input.GetKey (KeyCode.F)) {
			camera.orthographicSize = camera.orthographicSize - 15*Time.deltaTime;
			if(camera.orthographicSize < 70)
			{
				camera.orthographicSize = 70; // Min size 
			}
		}


		cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

	}
}
