using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour {
	
	public GameObject PauseMenuUI;
	bool paused;
    void Start()
	{
		PauseMenuUI.SetActive (false);
		paused = false;
    }

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused) {
				Resume ();
			} else {
				Pause ();
			}
		}	
	}

    public void Resume()
	{
		PauseMenuUI.SetActive (false);
		Time.timeScale = 1;
		paused = false;
	}

	public void Pause()
	{
		PauseMenuUI.SetActive (true);
		Time.timeScale = 0;
		paused = true;
	}

	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
	}

	public void Exit()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
		Application.Quit ();
	}

    public void Tutorial()
    {
        PlayerPrefs.SetInt("FirstTime", 2);
        PlayerPrefs.Save();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
