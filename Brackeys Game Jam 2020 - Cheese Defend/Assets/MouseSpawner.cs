using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{

    public GameObject mousePrefab;
    public int mouseAmount;
    int difficultScale = 0;

    public float timeBetweenWaves = 8f;
    private float timer;

    bool canBeSpawned = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenWaves;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            canBeSpawned = true;

        if (canBeSpawned) {
            canBeSpawned = false;
            timer = timeBetweenWaves;
            int multiplier = 3;

            if (difficultScale <= 10)
                multiplier = 4;

            if (difficultScale <= 8)
                multiplier = 3;

            if (difficultScale <= 5)
                multiplier = 2;

            if (difficultScale <= 3)
                multiplier = 1;

            for (int i = 0; i < mouseAmount * multiplier; i++)
            {
                Instantiate(mousePrefab, this.transform.position, Quaternion.identity);
            }

            difficultScale += 1;

        }
    }
}
