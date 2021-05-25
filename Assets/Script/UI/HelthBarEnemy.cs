using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthBarEnemy : Bar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.EnemyHealthCheanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _enemy.EnemyHealthCheanged -= OnValueChanged;
    }
}
