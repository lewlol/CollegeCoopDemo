using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    private void Update()
    {
        switch (state) 
        {
            case AbilityState.ready:
                break;
            case AbilityState.active:
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.coolDownTime;
                }
                break;
            case AbilityState.cooldown:
                if(cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;

        }

    }
    public void UseAbility(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (state == AbilityState.ready)
            {
                Debug.Log("Ability Used");
                ability.Activate(gameObject);
                state = AbilityState.active;
            }
            else
            {
                Debug.Log("Ability Unable to be used");
            }
        }
    }
}
