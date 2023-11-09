using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    public Vector2 player1Pos;
    public Vector2 player2Pos;

    private void Start()
    {
        CustomEventSystem.current.onPlayerDeath += SetSpawn;
        CustomEventSystem.current.onPlayerSpawned += PlayerAssign;
    }
    public void PlayerAssign(GameObject player)
    {
        if(player1 == null)
        {
            player1 = player;
        }
        else
        {
            player2 = player;
        }
    }

    public void StartMatch()
    {
        player1.transform.position = player1Pos;
        player2.transform.position = player2Pos;
    }

    public void SetSpawn(GameObject player)
    {
        if(player == player1)
        {
            player1.transform.position = player1Pos;
        }
        else
        {
            player2.transform.position = player2Pos;
        }
    }
}
