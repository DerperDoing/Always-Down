using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public Transform circle;
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= -1.4 && transform.position.x <= 194.75) {
			if (circle.position.x > transform.position.x) {
				transform.position = new Vector3 (circle.position.x, transform.position.y, transform.position.z);
			}
			else if (transform.position.x > 194.75) {
					transform.position = new Vector3 (194.75f, transform.position.y, transform.position.z);
			}
		} 
	}
}
