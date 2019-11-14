using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
	public float velocity, myGrav=9.8f;
    public Coroutine co;
	public bool collided;
	Rigidbody2D rb;
	public GameObject gameOver;
	public int flag=0;
	public int duration=2;
	DeviceOrientation or;
    Vector3 rotAngle;

	// Use this for initialization
	void Start () {
		or = Input.deviceOrientation;
		rb = GetComponent<Rigidbody2D> ();
        rotAngle = new Vector3(0, 0, 0);
		Physics2D.gravity = new Vector2 (0,-myGrav);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
//		Physics2D.gravity = new Vector2 (9.8f, 0);
	}

    // Update is called once per frame
   
    void move()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.GetKeyDown(KeyCode.RightArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(myGrav, 0);
            rotAngle.z = 90;
            co=StartCoroutine(Rotating(rotAngle));
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(-myGrav, 0);
            rotAngle.z = -90;
            co =StartCoroutine(Rotating(rotAngle));
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight || Input.GetKeyDown(KeyCode.UpArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(0, myGrav);
            rotAngle.z = 180;
            co =StartCoroutine(Rotating(rotAngle));
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.GetKeyDown(KeyCode.DownArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(0, -myGrav);
            rotAngle.z = 0;
            co =StartCoroutine(Rotating(rotAngle));
            Debug.Log("Inside MOVE()");
        }
    }


    void OnCollisionStay2D(Collision2D col){
        Debug.Log("Before CollisionStay");
		if ((rb != null) && !(rb.velocity.magnitude > 0) && (or != Input.deviceOrientation)) {
            Debug.Log("Calling Move()");
			move ();
        }
        Debug.Log("After CollisionStay");
    }

    IEnumerator Rotating(Vector3 rotAngle)
    {
        yield return new WaitForSeconds(0.1f);
        int startTime = (int)Time.time;
        int endTime = startTime + duration;
        Debug.Log("Start= "+ startTime);
        Debug.Log("End= " + endTime);
        while (Time.time < endTime)
        {
            velocity = rb.velocity.magnitude;
            float progress = (Time.time - startTime) / duration;
            Debug.Log("Time: " + Time.time);
            // progress will equal 0 at startTime, 1 at endTime.
            rb.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(this.rotAngle), progress);
            //rb.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(this.transform.rotation.eulerAngles.z, this.rotAngle.z, progress));
            Debug.Log("BEFORE null");
            yield return null;
            Debug.Log("AFTER null");
            if (rb.transform.rotation == Quaternion.Euler(rotAngle))
            {
                
                Debug.Log("Stopping Corotuine");
                StopCoroutine(co);
                yield break;
            }
        }
        Debug.Log("Co Later");
    }
    
//	void OnCollisionExit2D(){
//		collided = false;
//	}

//	void OnBecameInvisible(){
//		if(rb!=null){
//			gameOver.SetActive (true);
////			Destroy (rb);
//			//Time.timeScale = 0f;
//		}
//	}
}
