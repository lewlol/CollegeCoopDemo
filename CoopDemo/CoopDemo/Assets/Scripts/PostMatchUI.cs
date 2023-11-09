using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostMatchUI : MonoBehaviour
{
    public GameObject PostUI;
    public TextMeshProUGUI winMessage;


    private void Start()
    {
        CustomEventSystem.current.onTeamWin += EnableUI;
        CustomEventSystem.current.onTeamWin += TeamWinMessage;
    }
    public void EnableUI(Team team)
    {
        PostUI.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TeamWinMessage(Team team)
    {
        winMessage.text = team + " Team Wins!";
    }
}
