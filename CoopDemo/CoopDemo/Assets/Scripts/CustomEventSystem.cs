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

    public event Action<GameObject> onPlayerRespawn;
    public void PlayerRespawn(GameObject player)
    {
        if(onPlayerRespawn != null)
        {
            onPlayerRespawn(player);
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

    public event Action<Team, int> onPointGained;
    public void PointGained(Team team, int points)
    {
        if(onPointGained != null)
        {
            onPointGained(team, points);
        }
    }

    public event Action<Team, int> onPointsUpdate;
    public void PointsUpdate(Team team, int totalPoints)
    {
        if(onPointsUpdate != null)
        {
            onPointsUpdate(team, totalPoints);
        }
    }

    public event Action<Team> onTeamWin;
    public void TeamWin(Team team)
    {
        if(onTeamWin != null)
        {
            onTeamWin(team);
        }
    }

    public event Action onMatchStarted;
    public void MatchStarted()
    {
        if(onMatchStarted != null)
        {
            onMatchStarted();
        }
    }

    public event Action<Team, int, int> onPlayerHealthChange;
    public void PlayerHealthChange(Team team, int health, int maxhealth)
    {
        if(onPlayerHealthChange != null)
        {
            onPlayerHealthChange(team, health, maxhealth);
        }
    }
}
