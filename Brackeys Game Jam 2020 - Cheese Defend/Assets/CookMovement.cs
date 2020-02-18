using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMovement : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateTowardsMouse();



        if (Input.GetKey ("w"))
        {
            

            this.gameObject.transform.position += new Vector3(0, 0.1f * movementSpeed / 100, 0);

        }

        if (Input.GetKey("s"))
        {
            this.gameObject.transform.position += new Vector3(0, -0.1f * movementSpeed / 100, 0);
        }

        if (Input.GetKey("d"))
        {
            this.gameObject.transform.position += new Vector3(0.1f * movementSpeed / 100, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            this.gameObject.transform.position += new Vector3(-0.1f * movementSpeed / 100, 0, 0);
        }
    }

    void rotateTowardsMouse ()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //Vector3 diff = this.gameObject.transform.position + new Vector3(0, 0.1f * movementSpeed / 100, 0);


        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
