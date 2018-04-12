using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
	public float SecSpeed,speed,xTotal=0;
	bool collided=false;
	int xHit=0;
	Rigidbody2D rb;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb.AddForce (Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
			
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		foreach(ContactPoint2D hit in other.contacts)
		{
			if (hit.normal.x > 0) {
				xHit = 1;
				Debug.Log (hit.normal);
			} 
			else if (hit.normal.x < 0) {
				xHit = -1;
				Debug.Log (hit.normal);
			}
		}
	}

	void OnCollisionStay2D()
	{
		collided = true;
		Debug.Log ("Collide True");
		xTotal = Input.acceleration.x * Time.deltaTime; 
//		Debug.Log ("Collide Stay");
//		xVal = Input.acceleration.x;
//		string xValue = xVal.ToString ();
//		Debug.Log ("xVal: " + xValue);
//		Debug.Log ("dTime: " + Time.deltaTime);
//		xTotal = xVal * Time.deltaTime;
//		if (xTotal > 0.0186f) {
//			Debug.Log ("Right " + xTotal.ToString ());
//			Physics2D.gravity = new Vector3 (10f,0f,0f);
//			//rb.AddForce (Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
//			collided = false;
//		} else if (xTotal < -0.0186f) {
//			Debug.Log ("Left: " + xTotal.ToString ());
//			Physics2D.gravity = new Vector3 (-10f, 0f,0f);
//			//rb.AddForce (Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
//			collided = false;
//		}
	}
	/*void OnTriggerEnter2D()
	{
		Debug.Log ("Trigger Enter");
		if (xTotal > 0.0186f) {
			rb.AddForce (Vector2.right * SecSpeed * Time.deltaTime, ForceMode2D.Force);
		} 
		else if (xTotal < -0.0186f) {
			rb.AddForce (Vector2.left * SecSpeed * Time.deltaTime, ForceMode2D.Force);
		}
	}*/
}
