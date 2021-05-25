using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public int nextScene;

    public override void Interact()
    {
        SceneManager.LoadScene(nextScene);
    }
}
