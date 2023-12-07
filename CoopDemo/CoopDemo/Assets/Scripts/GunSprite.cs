using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprite : MonoBehaviour
{
    public SpriteRenderer sr;

    public void Start()
    {
        CustomEventSystem.current.onGunPickup += SwapSprite;
    }

    public void SwapSprite(Sprite gs)
    {
        sr.sprite = gs;
    }
}
