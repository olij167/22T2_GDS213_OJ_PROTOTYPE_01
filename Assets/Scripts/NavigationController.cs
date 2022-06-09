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
    public TextMeshProUGUI winText;

    public GameObject menuUI, healthBar;

    public string gameSceneName;
    public bool inGame;

    public UIController uiController;

    public AudioSource winAudioSource;
    public AudioClip winAudio;

    //public TutorialUIController tutorialUIController;

    private void Start()
    {
        //gameStarted = false;

        startText = startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        MainMenu();
        //tutorialUIController.enabled = false;

        Time.timeScale = 1f;
        inGame = false;

        startText.text = "Start";

        

    }
    public void StartGame()
    {
        player.enabled = true;
        camController.enabled = true;
        bombTilt.enabled = true;
        //tutorialUIController.enabled = true;

        //gameStarted = true;

        Time.timeScale = 1f;
        inGame = true;

        //uiController.UIFadeOut(menuUI.transform.GetChild(0).GetComponent<Image>(), 50f);

        menuUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (inGame)
        {
            healthBar.SetActive(true);
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
        else
        {
            healthBar.SetActive(false);
        }

        if (menuUI.activeSelf)
        {
            //uiController.UIHover(winText, 3f);
            //uiController.UIHover(menuUI.transform.GetChild(0).GetComponent<Image>(), 3f);
            //uiController.UIRotate(winText.transform.GetChild(0).GetComponent<TextMeshProUGUI>(), 3f);
            //uiController.UISizeLerp(menuUI.transform.GetChild(0).GetComponent<Image>(), 1f);
        }
    }

    public void Retry()
    {
        player.enabled = true;
        camController.enabled = true;
        bombTilt.enabled = true;
        inGame = false;


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
    public void WinGame()
    {
        player.enabled = false;
        camController.enabled = false;
        bombTilt.enabled = false;

        inGame = false;
        winText.enabled = true;
        winText.text = "YOU WIN!";
        winText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Nice One!";

        winAudioSource.PlayOneShot(winAudio);

        //uiController.UIHover(winText, 100f);

        //uiController.UIHover(winText.transform.GetChild(0).GetComponent<TextMeshProUGUI>(), 125f);
        

        menuUI.SetActive(true);
        startText.text = "Replay?";
        startButton.onClick.AddListener(Retry);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
