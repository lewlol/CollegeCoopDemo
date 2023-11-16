using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fireball")]
public class Fireball : Ability
{
    public float fireballSpeed;
    public GameObject fireball;

    GameObject fb;
    public override void Activate(GameObject parent)
    {
        fb = Instantiate(fireball, parent.transform.position, parent.transform.localRotation);
        fb.GetComponent<Rigidbody2D>().velocity = Vector2.up * fireballSpeed;
    }

    public override void BeginCooldown(GameObject parent)
    {
        Destroy(fb);
    }
}
