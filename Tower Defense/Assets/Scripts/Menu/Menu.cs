using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Button StartButton;
    public Button Exit;
    void Start()
    {
        StartButton.onClick.AddListener(() => StartGame());
        Exit.onClick.AddListener(() => ExitApp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitApp()
    {
        Application.Quit();
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
