using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.runSpeed += dashVelocity;
    }

    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.runSpeed -= dashVelocity;
    }
}
