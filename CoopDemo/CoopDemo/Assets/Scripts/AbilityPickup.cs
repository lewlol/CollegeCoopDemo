using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public GunData[] guns;
    public Ability[] abilities;
    Ability activeAbility;
    GunData activeGun;

    private void Awake()
    {
        int r = Random.Range(0, 2);
        if(r == 0)
        {
            ChooseAbility();
        }
        else if(r == 1)
        {
            ChooseGun();
        }
    }

    public void ChooseAbility()
    {
        int ranAbility = Random.Range(0, abilities.Length);
        activeAbility = abilities[ranAbility];
        GetComponent<SpriteRenderer>().sprite = activeAbility.abilityIcon;
    }

    public void ChooseGun()
    {
        int ranGun = Random.Range(0, guns.Length);
        activeGun = guns[ranGun];
        GetComponent<SpriteRenderer>().sprite = activeGun.gunSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(activeAbility != null)
            {
                collision.gameObject.GetComponent<AbilityHolder>().ability = activeAbility;
                Destroy(gameObject);
            }

            if(activeGun != null)
            {
                collision.gameObject.GetComponent<Shooting>().activeGun = activeGun;
                CustomEventSystem.current.GunPickup(activeGun.gunSprite);
                Destroy(gameObject);
            }
        }
    }
}
