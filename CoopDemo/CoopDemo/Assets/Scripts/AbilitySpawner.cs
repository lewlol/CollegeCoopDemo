using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpawner : MonoBehaviour
{
    public GameObject abilityPrefab;
    Vector2 spawnLocation;
    float countdown;

    private void Awake()
    {
        ResetCountdown();
    }
    public void SpawnPrefab()
    {
        Instantiate(abilityPrefab, spawnLocation, Quaternion.identity);
    }

    public void SetSpawnLocation()
    {
        float x = Random.Range(-12, 12);
        float y = Random.Range(-4, 6);

        spawnLocation = new Vector2(x, y);
    }

    public void ResetCountdown()
    {
        float c = Random.Range(15, 30);
        countdown = c;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            SetSpawnLocation();
            SpawnPrefab();
            ResetCountdown();
        }
    }
}
