using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPoints : MonoBehaviour
{
    public int teamRed;
    public int teamBlue;

    public int winPoints;

    private void Start()
    {
        CustomEventSystem.current.onPointGained += AddPoints;
    }
    public void AddPoints(Team team, int amount)
    {
        if (team == Team.Red)
        {
            teamRed += amount;
            CustomEventSystem.current.PointsUpdate(team, teamRed);
            if(teamRed >= winPoints)
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

    public void Win(Team team)
    {
        CustomEventSystem.current.TeamWin(team);
        Debug.Log(team + " Won");
    }
}
