using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawned : MonoBehaviour
{
    public void Awake()
    {
        CustomEventSystem.current.PlayerSpawned(gameObject);
    }
}
