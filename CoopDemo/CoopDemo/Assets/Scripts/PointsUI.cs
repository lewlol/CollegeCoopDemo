using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    public TextMeshProUGUI redPointsUI;
    public TextMeshProUGUI bluePointsUI;
    private void Start()
    {
        CustomEventSystem.current.onPointsUpdate += UpdateUI;
    }
    public void UpdateUI(Team team, int points)
    {
        if(team == Team.Red)
        {
            redPointsUI.text = points.ToString();
        }
        else
        {
            bluePointsUI.text = points.ToString();
        }
    }
}
