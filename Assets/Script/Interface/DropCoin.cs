using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bag bag))
        {
            Bag.Instance.AddMoney(5);
            Destroy(gameObject);
        }
    }
    public void Drop()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-75f, 75f), Random.Range(0f, 30f)));
    }
}
