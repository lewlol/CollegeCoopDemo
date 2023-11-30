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
                    //Nothing Needed Since 1 Per
                }
                break;

        }

    }
    public void UseAbility(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (state == AbilityState.ready && ability != null)
            {
                Debug.Log("Ability Used");
                ability.Activate(gameObject);
                state = AbilityState.active;
                ability = null;
            }
            else
            {
                Debug.Log("Ability Unable to be used");
            }
        }
    }
}
