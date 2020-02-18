using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEater : MonoBehaviour
{
    public int mouseDamage;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (target.CompareTag("cheese"))
            {
                target.GetComponent<CheeseHealth>().TakeDamage(mouseDamage);
                print("Mouse in trigger!");
            }
        }
        

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("cheese"))
        {
            target = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("cheese"))
        {
            Debug.Log("Leaving cheese...");
            target = null;
        }
    }
}
