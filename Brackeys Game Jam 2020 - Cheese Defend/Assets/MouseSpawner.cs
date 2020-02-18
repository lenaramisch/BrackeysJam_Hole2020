using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{

    public GameObject mousePrefab;
    public int mouseAmount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mouseAmount; i++)
        {
            Instantiate(mousePrefab, this.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
