using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    public PlayerData red;
    public PlayerData blue;

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
            player1.GetComponent<PlayerDataHolder>().pd = red;
        }
        else
        {
            player2 = player;
            player2.GetComponent<PlayerDataHolder>().pd = blue;
        }
    }

    public void StartMatch()
    {
        CustomEventSystem.current.MatchStarted();
        player1.transform.position = player1.GetComponent<PlayerDataHolder>().pd.spawnPos;
        player2.transform.position = player2.GetComponent<PlayerDataHolder>().pd.spawnPos;
    }

    public void SetSpawn(GameObject player)
    {
        if(player == player1)
        {
            player1.transform.position = player1.GetComponent<PlayerDataHolder>().pd.spawnPos;
        }
        else
        {
            player2.transform.position = player2.GetComponent<PlayerDataHolder>().pd.spawnPos;
        }
    }
}
