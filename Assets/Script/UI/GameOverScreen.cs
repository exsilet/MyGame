using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _panel;

    private CanvasGroup _gameOverGroup;


    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitMenu);
    }

    public void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitMenu);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
        _gameOverGroup.blocksRaycasts = false;
        
    }

    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
