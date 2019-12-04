using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gravity : MonoBehaviour {
    public float count, velocity, myGrav=9.8f;
    public Coroutine co;
	public bool collided;
	Rigidbody2D rb;
    Collider2D objCol;
	public EndUI gameOver;
    public int duration;
	DeviceOrientation or;
    Vector3 rotAngle;
    [SerializeField]float timeCollider=0.25f;

    void Start () {
        duration = 1;
        count = 0f;
		or = Input.deviceOrientation;
		rb = GetComponent<Rigidbody2D> ();
        objCol = GetComponent<Collider2D>();
        rotAngle = new Vector3(0, 0, 0);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Physics2D.gravity = new Vector2(0, -myGrav);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
            {
                Physics2D.gravity = new Vector2(-myGrav, 0);
                rb.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (Input.deviceOrientation == DeviceOrientation.Portrait)
            {
                Physics2D.gravity = new Vector2(myGrav, 0);
                rb.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                Physics2D.gravity = new Vector2(0, -myGrav);
            }
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            {
                Physics2D.gravity = new Vector2(0,myGrav);
                rb.transform.eulerAngles = new Vector3(0, 0, 180);
            }

        }
    }

    void move()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.GetKeyDown(KeyCode.RightArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(myGrav, 0);
            rotAngle.z = 90;
            co=StartCoroutine(Rotating(rotAngle));
            StartCoroutine(EnableCollider());
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(-myGrav, 0);
            rotAngle.z = 270;
            co =StartCoroutine(Rotating(rotAngle));
            StartCoroutine(EnableCollider());
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight || Input.GetKeyDown(KeyCode.UpArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(0, myGrav);
            rotAngle.z = 180;
            co =StartCoroutine(Rotating(rotAngle));
            StartCoroutine(EnableCollider());
            Debug.Log("Inside MOVE()");
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.GetKeyDown(KeyCode.DownArrow))
        {
            or = Input.deviceOrientation;
            Physics2D.gravity = new Vector2(0, -myGrav);
            rotAngle.z = 0;
            co =StartCoroutine(Rotating(rotAngle));
            StartCoroutine(EnableCollider());
            Debug.Log("Inside MOVE()");
        }
    }


    void OnCollisionStay2D(Collision2D col){
        //Debug.Log("Before CollisionStay");
		if ((rb != null) && (rb.velocity.magnitude < 0.001) && (or != Input.deviceOrientation) /*|| Input.anyKeyDown*/) {
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
        Debug.Log("objCol Status: " + objCol.enabled);
        //yield return new WaitForSeconds(0.2f);
        Debug.Log("objCol Status: " + objCol.enabled);
        //int startTime = (int)Time.unscaledDeltaTime;
        //int endTime = startTime + duration;
        //Debug.Log("Start= "+ startTime);
        //Debug.Log("End= " + endTime);
        while (count != duration)
        {
            velocity = rb.velocity.magnitude;
            Debug.Log("Rotation: " + rb.transform.eulerAngles + " rotAngle: " + rotAngle);
            //float progress = (Time.unscaledDeltaTime - startTime) / duration;
            Debug.Log("Time: " + Time.deltaTime);
            //Debug.Log("Difference: " + Mathf.Abs(rb.transform.eulerAngles.z - rotAngle.z));
            /*if (Mathf.Abs(rb.transform.eulerAngles.z - rotAngle.z) < 60)
            {
                objCol.enabled = true;
            }*/
            rb.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(this.rotAngle), count);
            Debug.Log("BEFORE null");
            count += Time.unscaledDeltaTime;
            yield return null;
            Debug.Log("AFTER null");
            if (rb.transform.eulerAngles == rotAngle)
            {
                //objCol.enabled = true;
                Debug.Log("Stopping Corotuine");
                //StopCoroutine(co);
                StopAllCoroutines();
                yield break;
            }
        }
        //objCol.enabled = true;
        Debug.Log("Co Later");
    }

    IEnumerator EnableCollider()
    {
        Debug.Log("Inside EnableCollider");
        yield return new WaitForSeconds(timeCollider);
        Debug.Log("After Waiting EnableCollider");
        objCol.enabled = true;
        Debug.Log("objCol Status: " + objCol.enabled);
    }

/*    void OnBecameInvisible()
    {
        if (rb != null)
        {
            Destroy(rb);
            gameOver.Restart();
            //gameOver.SetActive(true);
            
            //Time.timeScale = 0f;
        }
    }*/
}
