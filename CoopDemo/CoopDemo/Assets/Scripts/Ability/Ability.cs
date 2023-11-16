using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    [Header("Ability Information")]
    public new string name;
    public Sprite abilityIcon;

    [Header("AbilityStats")]
    public float coolDownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent) { }
    public virtual void BeginCooldown(GameObject parent) { }
}
