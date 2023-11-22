using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Team team;
    public Vector2 spawnPos;

    [Header("Sprites")]
    public Sprite idle;
    public Sprite[] walking;
}
