using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PanSwinger : MonoBehaviour
{
    public GameObject bloodprefab;
    public bool canKillMouse = false;
    public bool canSwingAgain = true;
    public GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSwingAgain)
        {
            canSwingAgain = false;

            canKillMouse = true;
            this.gameObject.GetComponent<Animator>().SetTrigger("isPressingMouse1Down");

        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (canKillMouse)
        {
            if (collider.gameObject.CompareTag("mouse"))
            {
                canKillMouse = false;
                GameObject blood = Instantiate(bloodprefab, collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(blood, 3f);
                collider.gameObject.GetComponent<CheeseEater>().gotHit = true;
                Destroy(collider.gameObject, 4f);
                scoreManager.GetComponent<ScoreManager>().score++;
            }
        }
    }
}
