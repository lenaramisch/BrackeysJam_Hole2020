using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{

    public GameObject mousePrefab;
    public int mouseAmount;
    int difficultScale = 0;

    public int multiplierOne = 3;
    public int multiplierTwo = 5;
    public int multiplierThree = 9;
    public int multiplierFour = 18;
    public AudioClip mouseVoiceSound;

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

            if (difficultScale <= multiplierFour)
                multiplier = 4;

            if (difficultScale <= multiplierThree)
                multiplier = 3;

            if (difficultScale <= multiplierTwo)
                multiplier = 2;

            if (difficultScale <= multiplierOne)
                multiplier = 1;

            for (int i = 0; i < mouseAmount * multiplier; i++)
            {
                Instantiate(mousePrefab, this.transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(mouseVoiceSound, new Vector3(5, 1, 2));
            }

            difficultScale += 1;

        }
    }
}
