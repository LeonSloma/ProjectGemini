using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class <c>GameOverUI</c> derives from <c>MonoBehaviour</c>.
/// Handles button input on gameover / level complete menu
/// </summary>
public class GameOverUI : MonoBehaviour
{

    public bool failed = false;
    public int nextLevel;
    public int mainMenu;

    /// <summary>
    /// Method <c>OnButtonClick</c> called on click of top
    /// button in menu.
    /// Reloads current scene, if players failed to complete
    /// the level.
    /// Loads next level, if successfully completed.
    /// </summary>
    public void OnButtonClick()
    {
        if(failed)
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                return;
            }
        SceneManager.LoadScene( nextLevel );
    }

    /// <summary>
    /// Method <c>OnMenuButtonClick</c> called on click of main
    /// menu button.
    /// Loads the main menu scene.
    /// </summary>
    public void onMenuButtonClick()
    {
        SceneManager.LoadScene( mainMenu );
    }
}
