using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKiller : MonoBehaviour
{

    public GameObject bloodprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Pan hit something!");
        if (collider.gameObject.CompareTag("mouse"))
        {
            Debug.Log("Hita the mouseH!");
            GameObject blood = Instantiate(bloodprefab, collider.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(blood, 3f);
            Destroy(collider.gameObject);
        }
    }
}
