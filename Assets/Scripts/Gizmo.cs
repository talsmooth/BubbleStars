using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gizmo : MonoBehaviour
{   Rigidbody rb;
    bool launch;
    bool launched;
    public float flyingSpeed;
    Vector3 startPos;
    bool changePos;
    bool isLeft;

    public int maxHits;
    int hits;


    public GameObject explosionEffect;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       startPos = new Vector3(0, transform.position.y + 0.4f, -0.15f);
       explosionEffect.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(Wait());
            explosionEffect.SetActive(true);




        }

        if (changePos)
        {
            
            transform.position = startPos;
            changePos = false;
        }

        if (launched) 
        {
            rb.velocity = new Vector3(-1, 1, 0) * flyingSpeed;
            transform.localEulerAngles = new Vector3(0, 180, -40);
        }

        if (launch)
        {
           
            if (transform.position.x > 1)
            {

                isLeft = false;

                if (!isLeft) 
                
                {
                    transform.localEulerAngles = new Vector3(0, 180, -40);
                    rb.velocity = new Vector3(-1, 1, 0) * flyingSpeed;

                }

            }
     

            if (transform.position.x < -1 )
            {
                launched = false;
                isLeft = true;

                if (isLeft )
                {
                    transform.localEulerAngles = new Vector3(0, 180, 40);
                    rb.velocity = new Vector3(1, 1, 0) * flyingSpeed;
                  
                }

            }

            if ( hits == maxHits )
            {
                GameObject tempExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(tempExplosion,2);
            }
         
            if (transform.position.y > 4.9f)
            {
                Destroy(gameObject);

            }

        }
    }


    IEnumerator Wait()
    {
        transform.position = startPos;
        yield return new WaitForSeconds(0.5f);
        launch = true;
        launched = true;
        changePos = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bubble")
        {
            hits++;
            Destroy(other.gameObject);

        }
    }

}
