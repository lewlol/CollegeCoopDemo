using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Team activeTeam;
    bool matchStarted;
    bool startGenningPoints;
    float c = 0.5f;
    float g = 0.5f;

    public GameObject[] squares;

    private void Start()
    {
        CustomEventSystem.current.onMatchStarted += MatchStarted;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Colliding");
            activeTeam = collision.gameObject.GetComponent<PlayerDataHolder>().pd.team;
            startGenningPoints = true;
            ColorTest(collision.gameObject.GetComponent<PlayerDataHolder>().pd.team);
        }
    }

    public void MatchStarted()
    {
        matchStarted = true;
    }

    private void Update()
    {
        if(matchStarted && startGenningPoints)
        {
            float countdown = c -= Time.deltaTime;
            if(countdown <= 0)
            {
                Debug.Log("Point for the " + activeTeam + " Team");
                CustomEventSystem.current.PointGained(activeTeam, 1);
                c = 0.5f;
            }
        }


    }

    public void ColorTest(Team team)
    {
        foreach (GameObject s in squares)
        {
            if(team == Team.Red)
            {
                s.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                s.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }
}
