using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanSwinger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("isPressingMouse1Down");
        }
        
    }
}
