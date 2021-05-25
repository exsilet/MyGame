using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private int _damage;
    [SerializeField] private int _rollImpulse = 200;
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponNumber = 0;
    private bool lockRoll = false;

    private Firearms _currentFirearms;
    private EdgedWeapons _currentEdgedWeapon;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private PlayerInput _input;
    private Vector2 _move;

    public int _currentHealth;
    public float checkRadius;
    public bool faceRight = true;
    public bool isGrounded;

    public Transform groundCheck, shootPoint, atackPoint;
    public LayerMask layerMask;


    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> HealthTextChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthTextChanged?.Invoke(_currentHealth, _health);
    }

    private void Awake()
    {
        _input = new PlayerInput();
        _currentHealth = _health;

        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        ChangeWeapon(_weapons[_currentWeaponNumber]);

        _input.Player.Hit.performed += ctx => Hit();
        _input.Player.Jump.performed += ctx => Jump();
        _input.Player.Roll.performed += ctx => Roll();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();
        Move(moveDirection);
        ChekinGround();
    }

    public void Hit()
    {
        if (_currentWeaponNumber == 0)
        {
            _animator.SetTrigger("Attack");
            _currentEdgedWeapon.Hit(atackPoint);
        }
        else if (_currentWeaponNumber == 1)
        {
            _animator.SetTrigger("AttackBow");
            _currentFirearms.Shoot(shootPoint);
        }
        else
        {
            Debug.Log("нет оружия");
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        if (_currentEdgedWeapon == null )
        {
            _currentEdgedWeapon = (EdgedWeapons)weapon;

        }
        else if (_currentFirearms == null)
        {
            _currentFirearms = (Firearms)weapon;
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _animator.SetTrigger("Hurt");

        HealthChanged?.Invoke(_currentHealth, _health);
        HealthTextChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            _animator.SetBool("DieBow", true);
            Destroy(gameObject, 0.8f);
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }

    private void Move(Vector2 direction)
    {
        float sacaleMoveSpeed = _speed * Time.deltaTime;
        _animator.SetFloat("Speed", Mathf.Abs(direction.x));
        Vector3 curentPosition = new Vector3(direction.x, direction.y);

        if ((direction.x > 0 && !faceRight) || (direction.x < 0 && faceRight))
        {
            faceRight = !faceRight;
            transform.Rotate(0, 180 ,0);
        }

        transform.position += curentPosition * sacaleMoveSpeed;
    }

    private void ChekinGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerMask);
        _animator.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jump);
        }
    }

    private void Roll()
    {
        if (!lockRoll)
        {
            lockRoll = true;
            Invoke("LangeLock", 1f);

            _animator.StopPlayback();
            _animator.SetTrigger("Roll");

            _rigidbody.velocity = new Vector2(0, 0);

            if (!faceRight)
                _rigidbody.AddForce(Vector2.left * _rollImpulse);
            else
                _rigidbody.AddForce(Vector2.right * _rollImpulse);
        }   
    }

    public void LangeLock()
    {
        lockRoll = false;
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count-1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count- 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }
}