using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider redSlider;
    public Slider blueSlider;

    private void Start()
    {
        CustomEventSystem.current.onPlayerHealthChange += UpdateHealthUI;
    }
    public void UpdateHealthUI(Team team, int health, int maxHealth)
    {
        if(team == Team.Red)
        {
            redSlider.maxValue = maxHealth;
            redSlider.value = health;
        }
        else
        {
            blueSlider.maxValue = maxHealth;
            blueSlider.value = health;
        }
    }
}
