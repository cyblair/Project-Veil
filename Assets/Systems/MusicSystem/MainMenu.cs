using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("New Super Dialogue System (1)");
        MusicManager.Instance.Stop();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
