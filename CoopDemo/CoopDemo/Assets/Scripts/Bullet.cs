using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask objects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == objects)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(15);
            Destroy(gameObject);
        }
    }
}
