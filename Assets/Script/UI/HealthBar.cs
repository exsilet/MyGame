using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _barText;


    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _player.HealthTextChanged += OnValueTextChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
        _player.HealthTextChanged -= OnValueTextChanged;
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }

    public void OnValueTextChanged(int value, int maxValue)
    {
        _barText.text = $"{(float)value} / {maxValue}";
    }
}
