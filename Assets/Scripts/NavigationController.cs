using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NavigationController : MonoBehaviour
{
    public PlayerController player;
    public CamController camController;
    public BombTilt bombTilt;

    public Button retryButton, menuButton, quitButton, startButton, tutorialButton;
    TextMeshProUGUI startText;

    public GameObject menuUI;

    public string gameSceneName;
    //public bool gameStarted;

    //public TutorialUIController tutorialUIController;

    private void Start()
    {
        //gameStarted = false;

        startText = startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        MainMenu();
        //tutorialUIController.enabled = false;

        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        player.enabled = true;
        camController.enabled = true;
        bombTilt.enabled = true;
        //tutorialUIController.enabled = true;

        //gameStarted = true;

        Time.timeScale = 1f;

        menuUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P))
        {
            if (!menuUI.activeSelf)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void Retry()
    {
        player.enabled = true;
        camController.enabled = true;
        bombTilt.enabled = true;
        //gameStarted = false;


        SceneManager.LoadScene(gameSceneName);
    }

    public void MainMenu()
    {
        player.enabled = false;
        camController.enabled = false;
        bombTilt.enabled = false;
        Time.timeScale = 0f;
        menuUI.gameObject.SetActive(true);

        //if (gameStarted)
        //{
        //    startText.text = "Continue";

        //    startButton.onClick.AddListener(ResumeGame);
        //}
        
    }

    public void PauseGame()
    {
        player.enabled = false;
        camController.enabled = false;
        bombTilt.enabled = false;

        Time.timeScale = 0f;

        menuUI.gameObject.SetActive(true);

        startText.text = "Continue";
        startButton.onClick.AddListener(ResumeGame);
    }

    public void ResumeGame()
    {
        player.enabled = true;
        camController.enabled = true;
        bombTilt.enabled = true;
        Time.timeScale = 1f;
        menuUI.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
