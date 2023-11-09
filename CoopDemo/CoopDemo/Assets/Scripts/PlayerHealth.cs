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
        CustomEventSystem.current.PlayerHealthChange(gameObject.GetComponent<PlayerDataHolder>().pd.team, health, maxHealth);
        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void HealPlayer()
    {
        health = maxHealth;
        CustomEventSystem.current.PlayerHealthChange(gameObject.GetComponent<PlayerDataHolder>().pd.team, health, maxHealth);
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

        HealPlayer();
        CustomEventSystem.current.PlayerRespawn(gameObject);

        bc.enabled = true;
        sr.enabled = true;
        srr.enabled = true;
    }
}
