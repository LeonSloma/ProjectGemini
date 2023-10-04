using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : Interactable
{

    public int scene;
    [SerializeField]

    public override void Interact()
    {
        if (scene == -1) Application.Quit();
        else SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }


}
