using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ContinueTheGame(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {
        Menu_Game.Load();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        One_level.Load();
    }
}
