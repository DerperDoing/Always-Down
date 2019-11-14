using UnityEngine;

public class Goal : MonoBehaviour {

	public GameObject gameObj;
	public Rigidbody2D rb;
    public EndUI po;
    private void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("In Goal.cs");
        po.Pause();
        Time.timeScale = 0;
    }
}
