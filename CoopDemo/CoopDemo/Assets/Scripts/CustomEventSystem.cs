using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem current;
    private void Awake()
    {
        current = this;
    }

    public event Action<GameObject> onPlayerSpawned;
    public void PlayerSpawned(GameObject player)
    {
        if(onPlayerSpawned != null)
        {
            onPlayerSpawned(player);
        }
    }

    public event Action<GameObject> onPlayerDeath;
    public void PlayerDeath(GameObject player)
    {
        if(onPlayerDeath != null)
        {
            onPlayerDeath(player);
        }
    }
}
