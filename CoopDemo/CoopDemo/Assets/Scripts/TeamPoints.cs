using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPoints : MonoBehaviour
{
    public int teamRed;
    public int teamBlue;

    public int winPoints;

    bool gameWon;
    private void Start()
    {
        CustomEventSystem.current.onPointGained += AddPoints;
        CustomEventSystem.current.onTeamWin += GameWon;
    }
    public void AddPoints(Team team, int amount)
    {
        if (!gameWon)
        {
            if (team == Team.Red)
            {
                teamRed += amount;
                CustomEventSystem.current.PointsUpdate(team, teamRed);
                if (teamRed >= winPoints)
                {
                    Win(team);
                }
            }
            else
            {
                teamBlue += amount;
                CustomEventSystem.current.PointsUpdate(team, teamBlue);
                if (teamBlue >= winPoints)
                {
                    Win(team);
                }
            }
        }
    }

    public void GameWon(Team team)
    {
        gameWon = true;
    }

    public void Win(Team team)
    {
        CustomEventSystem.current.TeamWin(team);
        Debug.Log(team + " Won");
    }
}
