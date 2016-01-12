using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Vector3 dPosition;
	Quaternion dRotation; // For movement
	public float speed = 2.0f;                 // Speed of movement
	public float rotationSpeed=90f; // speed of rotation

	void Start () {
		dRotation = transform.rotation;          // Take the initial position
		dPosition = transform.position;
	}
	
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)&& transform.rotation == dRotation) {       // Left
			dRotation*= Quaternion.Euler(0f,0f,90f);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)&& transform.rotation == dRotation) {        // Right
			dRotation*= Quaternion.Euler(0f,0f,-90f);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position == dPosition) {        // Up

			dPosition-=dRotation*Vector3.up;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position == dPosition) {        // Down
			dPosition+=dRotation*Vector3.up;

		}
		
		transform.position = Vector3.Lerp(transform.position, dPosition, Time.deltaTime * speed);    // Move there
		transform.rotation = Quaternion.Lerp(transform.rotation, dRotation, rotationSpeed * Time.deltaTime);


	}

	void RotateLeft () {

		}

	void RotateRight () {
	}
}
