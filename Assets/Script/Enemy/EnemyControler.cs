using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyControler : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private Transform[] _point;
    private SpriteRenderer _sprite;
    private Animator _animator;
    private int _curentPoint;
    private int _move = 1;
    //public Ray2D ray;

    //public event UnityAction Dying;

    public void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _point = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _point[i] = _way.GetChild(i);
        }
    }

    public void Update()
    {
        Mover();
    }

    private void Mover()
    {
        Transform target = _point[_curentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _curentPoint++;
            Reflect(-_move);


            if (_curentPoint >= _point.Length)
            {
                _curentPoint = 0;
                Reflect(_move);
            }
        }
    }

    private void Reflect(int move)
    {
        transform.localScale *= new Vector2(move, 1);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;


        if (_health <= 0)
        {
            _animator.SetTrigger("Die");
            _animator.Play("impac");
            Destroy(gameObject, 0.8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _animator.SetTrigger("Attack");
            player.ApplyDamage(_damage);
        }
    }
}
