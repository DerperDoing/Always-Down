using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public Transform target;
	public float xBound, speed=0.01f;	
	public Vector3 offset;
	Vector2 min,max;
	float camHalfWidth;
	public BoxCollider2D camBound;
	Camera cam;

	void Start()
	{
		cam = GetComponent<Camera> ();
		camHalfWidth = cam.orthographicSize * ((float) Screen.width / Screen.height);
		min= camBound.bounds.min;
		max= camBound.bounds.max;
	}

	void FixedUpdate () {
			if ((target.position - transform.position).magnitude > xBound) {
				Vector3 desiredPos = target.position + offset;
				Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, speed);
				transform.position = smoothedPos;
			}

		//Clamping Camera withing the Level Bounds
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, min.x + camHalfWidth, max.x - camHalfWidth),
			Mathf.Clamp (transform.position.y, min.y + cam.orthographicSize, max.y - cam.orthographicSize),
			transform.position.z);
	}
}
