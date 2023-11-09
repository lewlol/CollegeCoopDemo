using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Vector2 spawnPosition;

    public int health;
    int maxHealth = 100;

    private void Awake()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        CustomEventSystem.current.PlayerDeath(gameObject);

        //Death
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        SpriteRenderer srr = GetComponentInChildren<SpriteRenderer>();

        bc.enabled = false;
        sr.enabled = false;
        srr.enabled = false;

        yield return new WaitForSeconds(5f);

        bc.enabled = true;
        sr.enabled = true;
        srr.enabled = true;
    }
}
