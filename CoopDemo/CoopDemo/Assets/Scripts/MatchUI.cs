using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchUI : MonoBehaviour
{
    public GameObject mUI;

    private void Start()
    {
        CustomEventSystem.current.onTeamWin += DisableUI;
    }

    public void DisableUI(Team team)
    {
        mUI.SetActive(false);
    }
}
