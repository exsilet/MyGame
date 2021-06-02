using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Box : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private SpriteRenderer _sprite;
    private Animator _animator;

    public void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;

        _animator.SetTrigger("Damage");

        if (_health <= 0)
        {
            _animator.SetTrigger("Die");
            Destroy(gameObject, 0.8f);
        }
    }
}
