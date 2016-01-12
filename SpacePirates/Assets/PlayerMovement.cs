using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float maxSpeed = 5f; //maxspeed for ship
	public float rotSpeed = 180f; //rotation Speed
	float shipBoundaries = 0.5f; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		// ROTATE the ship.

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// Grab the Z Euler angle
		float z = rot.eulerAngles.z;

		// Change the Z angle based on input
		z += -Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

		// Make new Quaternion
		rot = Quaternion.Euler (0,0,z);

		// Apply to object rotation
		transform.rotation = rot; 

		// MOVE the ship

		// Grab the position Vector3
		Vector3 pos = transform.position;

		// Change the vertical axis based on input, speed and deltaTime
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0); 

		// move the ship based on Rotation
		pos += rot * velocity;


		// RESTRICT the player to the camera's boundaries

		// restrict the vertical movement of the ship
		if (pos.y + shipBoundaries > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaries;
		}

		if (pos.y - shipBoundaries < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaries;
		}

		// calculate the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;

		//calculate the orthographic width
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// restrict the horizontal movement
		if (pos.x + shipBoundaries > widthOrtho) {
			pos.x = widthOrtho - shipBoundaries;
		}

		if (pos.x - shipBoundaries < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaries;
		}

		// Apply the change to object position
		transform.position = pos;


	}
}
