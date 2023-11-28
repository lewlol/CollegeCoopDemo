using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public Ability[] abilities;
    Ability activeAbility;

    private void Awake()
    { 
        ChooseAbility();
    }

    public void ChooseAbility()
    {
        int ranAbility = Random.Range(0, abilities.Length);
        activeAbility = abilities[ranAbility];
        GetComponent<SpriteRenderer>().sprite = activeAbility.abilityIcon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<AbilityHolder>().ability = activeAbility;
            Destroy(gameObject);
        }
    }
}
