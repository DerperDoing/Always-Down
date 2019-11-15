using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    public float count, velocity, myGrav=9.8f;
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
        duration = 1;
        count = 0f;
		or = Input.deviceOrientation;
		rb = GetComponent<Rigidbody2D> ();
        objCol = GetComponent<Collider2D>();
        rotAngle = new Vector3(0, 0, 0);
		Physics2D.gravity = new Vector2 (0,-myGrav);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
//		Physics2D.gravity = new Vector2 (9.8f, 0);
	}

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
            rotAngle.z = 270;
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
        //Debug.Log("Before CollisionStay");
		if ((rb != null) && (rb.velocity.magnitude < 0.001) && (or != Input.deviceOrientation) || Input.anyKeyDown) {
            Debug.Log("Calling Move()");
            Physics2D.gravity = new Vector2(0, 0);
            move ();
        }
        //Debug.Log("After CollisionStay");
    }

    IEnumerator Rotating(Vector3 rotAngle)
    {
        count = 0;
        objCol.enabled = false;
        yield return new WaitForSeconds(0.2f);
        int startTime = (int)Time.unscaledDeltaTime;
        //int endTime = startTime + duration;
        Debug.Log("Start= "+ startTime);
        //Debug.Log("End= " + endTime);
        while (count != duration)
        {
            velocity = rb.velocity.magnitude;
            Debug.Log("Rotation: " + rb.transform.eulerAngles + " rotAngle: " + rotAngle);
            //float progress = (Time.unscaledDeltaTime - startTime) / duration;
            Debug.Log("Difference: " + Mathf.Abs(rb.transform.eulerAngles.z - rotAngle.z));
            if (Mathf.Abs(rb.transform.eulerAngles.z - rotAngle.z) < 30)
            {
                objCol.enabled = true;
            }
            rb.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(this.rotAngle), count);
            Debug.Log("BEFORE null");
            count += Time.deltaTime;
            yield return null;
            Debug.Log("AFTER null");
            if (rb.transform.eulerAngles == rotAngle)
            {
                objCol.enabled = true;
                Debug.Log("Stopping Corotuine");
                StopCoroutine(co);
                yield break;
            }
        }
        //objCol.enabled = true;
        Debug.Log("Co Later");
    }


//	void OnBecameInvisible(){
//		if(rb!=null){
//			gameOver.SetActive (true);
////			Destroy (rb);
//			//Time.timeScale = 0f;
//		}
//	}
}
