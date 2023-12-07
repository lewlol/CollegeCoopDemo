using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun")]
public class GunData : ScriptableObject
{
    public float bulletSpeed;
    public float bulletTime;
    public float shootDelay;
    public int damage;
    public Sprite gunSprite;
}
