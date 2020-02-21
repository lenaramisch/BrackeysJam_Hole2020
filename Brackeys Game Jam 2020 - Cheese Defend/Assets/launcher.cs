using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{

    public float magnitude = 2500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mouse"))
        {

            var force = transform.position - collision.gameObject.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

        }
    }
}
