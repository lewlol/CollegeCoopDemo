using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask objects;
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == objects)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == objects)
        {
            Destroy(gameObject);
        }
    }
}
