using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
	public float velocity, myGrav=19.5f;
	public bool collided;
	public Rigidbody2D rb;
	public GameObject gameOver;
	public int flag=0;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Physics2D.gravity = new Vector2 (0, -myGrav);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
//		Physics2D.gravity = new Vector2 (9.8f, 0);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (velocity);
//		Debug.Log (Input.deviceOrientation.ToString());
		if (rb!=null && rb.velocity.magnitude<0.4 && collided) {
			move ();
		}
	}

	void move(){
		if (Input.deviceOrientation == DeviceOrientation.Portrait && flag!=2) {
			Physics2D.gravity = new Vector2 (myGrav, 0);
//			rb.AddForce (Vector2.right * Speed, ForceMode2D.Impulse);
			flag=1;
		} else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown && flag!=1) {
			Physics2D.gravity = new Vector2 (-myGrav, 0);
//			rb.AddForce (Vector2.left * Speed, ForceMode2D.Impulse);
			flag=2;
		} else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight && flag!=4) {
			Physics2D.gravity = new Vector2 (0, myGrav);
//			rb.AddForce (Vector2.up * Speed, ForceMode2D.Impulse);
			flag=3;
		} else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && flag!=3) {
			Physics2D.gravity = new Vector2 (0, -myGrav);
//			rb.AddForce (Vector2.down * Speed, ForceMode2D.Impulse);
			flag=4;
		}
	}

//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.CompareTag ("Finish")) {			
//			gameOver.SetActive (true);
//			Destroy (rb);
//		}
//	}
	void OnCollisionStay2D(Collision2D col){
		collided = true;
	}

	void OnCollisionExit2D(){
		collided = false;
	}

	public void OnBecameInvisible(){
		if(rb!=null){
			gameOver.SetActive (true);
			Destroy (rb);
			//Time.timeScale = 0f;
		}
	}
}
