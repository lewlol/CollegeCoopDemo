using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingAnimation : MonoBehaviour
{
    public PlayerData pd;
    public SpriteRenderer sr;
    public Sprite idle;
    public Sprite[] walking;

    bool isWalking;
    int s;
    float c = 0.1f;
    float sReset = 0.1f;

    private void Start()
    {
        CustomEventSystem.current.onPlayerMove += CheckWalking;
    }
    private void Awake()
    {
        StartCoroutine(AssignSprites());
    }
    public void CheckWalking(bool t)
    {
        isWalking = t;
    }
    private void Update()
    {
        if (isWalking)
        {
            c -= Time.deltaTime;
            if(c <= 0)
            {
                s++;
                if(s >= walking.Length)
                {
                    s = 0;
                }

                sr.sprite = walking[s];
                c = sReset;
            }
        }
        else
        {
            sr.sprite = idle;
        }
    }

    public IEnumerator AssignSprites()
    {
        yield return new WaitForSeconds(0.1f);
        idle = gameObject.GetComponent<PlayerDataHolder>().pd.idle;
        walking = gameObject.GetComponent<PlayerDataHolder>().pd.walking;
    }
}
