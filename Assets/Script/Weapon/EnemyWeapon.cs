using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    public LayerMask enemyLayer;
    public float attackDistance;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, attackDistance, enemyLayer);

        Debug.DrawRay(transform.position, transform.right * attackDistance, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("Враг" + hit.collider);
            if (hit.collider.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.ApplyDamage(_damage);
                Destroy(gameObject, 0.01f);
            }
        }
        else
        {
            Destroy(gameObject, 0.8f);
        }
    }
}
