using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class EndGoal : MonoBehaviour {

	//public GameObject gameObj;
	public Rigidbody2D rb;
    public EndUI po;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(LoadNextlevel());
        }
        else
        {
            po.Pause();
            Time.timeScale = 0;
        }
    }

    IEnumerator LoadNextlevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
