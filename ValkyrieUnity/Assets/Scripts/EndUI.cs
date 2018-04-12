using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour {

	public void Restart(){
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex) ;
	}

	public void Exit(){
		Application.Quit ();
	}
}
