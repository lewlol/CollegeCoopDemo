using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fireball")]
public class Fireball : Ability
{
    public float fireballSpeed;
    public GameObject fireball;

    GameObject fb;
    float rotation;
    private void Awake()
    {
        CustomEventSystem.current.onPlayerRotated += GrabRotation;
    }
    public override void Activate(GameObject parent)
    {
        fb = Instantiate(fireball, parent.transform.position, parent.transform.localRotation);
        Vector2 shootDir = Quaternion.Euler(0, 0, rotation) * Vector2.up;
        fb.GetComponent<Rigidbody2D>().velocity = shootDir * fireballSpeed;
        DestroyObject(fb);
    }

    public void GrabRotation(float rot)
    {
        rotation = rot;
    }

    public void DestroyObject(GameObject fb)
    {
        Destroy(fb, 5);
    }
}
