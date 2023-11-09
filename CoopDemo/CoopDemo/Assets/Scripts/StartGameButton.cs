using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public GameObject startButton;

    private void Start()
    {
        CustomEventSystem.current.onMatchStarted += DisableButton;
    }
    public void DisableButton()
    {
        startButton.SetActive(false);
    }
}
