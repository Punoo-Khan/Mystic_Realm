using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    private GameObject target;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Find the enemy gameobject, replace "Enemy" with your enemy's tag
        target = GameObject.FindGameObjectWithTag("enemy");
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;

        }
        else
        {
            // If no target found, destroy the bullet after some time, here it is 2 seconds.
            Destroy(gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy" )
            Destroy(gameObject);
    }
}
