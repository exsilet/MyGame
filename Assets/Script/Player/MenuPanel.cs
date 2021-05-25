using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    private PlayerInput _input;
    
    public GameObject _panel;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Interface.MenuPanel.performed += ctx => OpenPanel();
    }


    private void OnEnable()
    {
        _input.Interface.Enable();
    }

    private void OnDisable()
    {
        _input.Interface.Disable();
    }

    public void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
}
