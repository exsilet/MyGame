using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Bag _bag;

    private void OnEnable()
    {
        _bag.MoneyChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _bag.MoneyChanged -= OnValueChanged;
    }

    public void OnValueChanged(int value)
    {
        _money.text = _bag.MoneyCount.ToString();
    }
}
