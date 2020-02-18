using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject Cheese;
    public float speed;

    private Transform myEatingPlace;

    // Start is called before the first frame update
    void Start()
    {
        List<Transform> ep = Cheese.GetComponent<Eatingplaces>().eatingPlaces;
        myEatingPlace = ep[Random.Range(0, ep.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, myEatingPlace.position, step);



        Vector3 vectorToTarget = Cheese.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

    }
}