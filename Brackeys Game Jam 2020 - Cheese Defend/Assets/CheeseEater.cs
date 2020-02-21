using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEater : MonoBehaviour
{
    public int mouseDamage;
    public float speed;
    public float distanceToKeep = 0.5f;
    public GameObject target;
    public GameObject Cheese;

    public bool gotHit = false;

    private Transform myEatingPlace;

    // Start is called before the first frame update
    void Start()
    {
        Cheese = GameObject.Find("Big Cheese");
        List<Transform> ep = Cheese.GetComponent<Eatingplaces>().eatingPlaces;
        myEatingPlace = ep[Random.Range(0, ep.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Cheese.transform.position, this.transform.position);

        if (dist >= distanceToKeep && !gotHit)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, myEatingPlace.position, step);

            Vector3 vectorToTarget = Cheese.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

        if (target != null)
        {
            if (target.CompareTag("cheese"))
            {
                target.GetComponent<CheeseHealth>().TakeDamage(mouseDamage);
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
