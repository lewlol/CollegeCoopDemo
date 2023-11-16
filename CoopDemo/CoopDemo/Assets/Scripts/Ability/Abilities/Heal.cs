using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal")]
public class Heal : Ability
{
    public int healAmount;

    public override void Activate(GameObject parent)
    {
        parent.GetComponent<PlayerHealth>().HealPlayer(healAmount);
    }
}
