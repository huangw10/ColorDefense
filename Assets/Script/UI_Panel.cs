using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class UI_Panel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart()
    {
        NetworkManager.Shutdown();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        tomb.num_tomb = 0;
    }

    public void RestartCompetitive()
    {
        NetworkManager.Shutdown();
        SceneManager.LoadScene("Competitive");
        Time.timeScale = 1.0f;
        tomb.num_tomb = 0;
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
