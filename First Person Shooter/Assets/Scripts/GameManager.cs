using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        SetUpSingleton();

        player = FindObjectOfType<PlayerController>();
    }

    private void SetUpSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "GameOver")
        {
            Cursor.visible = true;
        }
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
