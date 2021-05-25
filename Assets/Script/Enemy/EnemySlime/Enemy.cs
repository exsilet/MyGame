using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _target;

    private Animator _animator;
    private int _currentHealth;

    public GameObject coin;
    public Player Target => _target;
    public event UnityAction<int, int> EnemyHealthCheanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        EnemyHealthCheanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            //Dying?.Invoke(this);
            _animator.SetTrigger("Die");

            int count = Random.Range(5, 10);

            var positionEnemy = transform.position;

            for (int i = 0; i < count; i++)
            {
               var coinEnemyDrop = Instantiate(coin, new Vector3(positionEnemy.x, positionEnemy.y + i, positionEnemy.z), Quaternion.identity);
                
               coinEnemyDrop.GetComponent<DropCoin>().Drop();
            }

            Destroy(gameObject, 0.8f);
        }
    }
}
