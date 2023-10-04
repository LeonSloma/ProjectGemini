using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI titleText;
    [SerializeField]
    protected GameObject resumeButton;

    public void showPauseMenu()
    {
        this.gameObject.SetActive(true);
        resumeButton.SetActive(true);
        titleText.SetText("PAUSED");
        Time.timeScale = 0;
    }

    public void showGameOverMenu()
    {
        this.gameObject.SetActive(true);
        resumeButton.SetActive(false);
        titleText.SetText("GAME OVER");
        Time.timeScale = 0;
    }

    public void OnResumeClick()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1;
    }

    public void OnQuitClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
