using UnityEngine;

public class Goal : MonoBehaviour {

	public GameObject gameObj;
	public Rigidbody2D rb;

	void OnCollisionStay2D(Collision2D col){
		gameObj.SetActive (true);
		Destroy (rb);
	}
}
