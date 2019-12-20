using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("First Time: " + PlayerPrefs.HasKey("FirsTime"));
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            Debug.Log("Inside HasKey: " + PlayerPrefs.HasKey("FirstTime"));
            Debug.Log("HasKey Value: " + PlayerPrefs.GetInt("FirstTime"));
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(1);
        }
        else if (PlayerPrefs.GetInt("FirstTime") == 1) //Loads Level 1
        {
            Debug.Log("Inside Else GetInt");
            SceneManager.LoadSceneAsync(2);
        }
        else if (PlayerPrefs.GetInt("FirstTime") == 2) //Loads Level Tutorial
        {
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(1);
        }
    }
}
