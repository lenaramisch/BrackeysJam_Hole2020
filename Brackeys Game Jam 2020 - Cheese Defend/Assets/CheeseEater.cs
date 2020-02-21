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
    public float timebetweenEating = 2f;
    public float recoveryTime = 2f;

    bool canEat = true;
    private float timer;
    private float recoveryTimer;

    // Start is called before the first frame update
    void Start()
    {
        Cheese = GameObject.Find("Big Cheese");
        List<Transform> ep = Cheese.GetComponent<Eatingplaces>().eatingPlaces;
        myEatingPlace = ep[Random.Range(0, ep.Count)];
        timer = timebetweenEating;
        recoveryTimer = recoveryTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            canEat = true;
        //Movement of Mouse
        float dist = Vector3.Distance(Cheese.transform.position, this.transform.position);

        if (dist >= distanceToKeep && !gotHit)
        {
            recoveryTimer = recoveryTime;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, myEatingPlace.position, step);

            Vector3 vectorToTarget = Cheese.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        } else
        {
            recoveryTimer -= Time.deltaTime;
            if (recoveryTimer <= 0)
                gotHit = false;
        }

        if (canEat)
            Eating();
        
    }

    void Eating()
    {
        if (target == null)
            return;

        if (target.CompareTag("cheese"))
        {
            canEat = false;
            timer = timebetweenEating;
            target.GetComponent<CheeseHealth>().TakeDamage(mouseDamage);
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
