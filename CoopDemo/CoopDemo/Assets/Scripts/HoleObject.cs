using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(9999);
        }
    }
}
