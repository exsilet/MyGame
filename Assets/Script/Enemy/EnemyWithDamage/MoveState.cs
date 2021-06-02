using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private int _move = -1;

    public Transform targetPlaye;
    public bool isFlipped = false;

    private void Update()
    {
        Move();
        LookAtPlayer();
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void Reflect(int move)
    {
        transform.localScale = new Vector3(move, 1, 1);
    }

    public void LookAtPlayer()
    {
        if (transform.position.x > targetPlaye.position.x && isFlipped)
        {
            Reflect(_move);
            isFlipped = false;
        }
        else if (transform.position.x < targetPlaye.position.x && !isFlipped)
        {
            Reflect(-_move);
            isFlipped = true;
        }
    }
}
