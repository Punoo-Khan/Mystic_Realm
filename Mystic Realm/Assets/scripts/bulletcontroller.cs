using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    private GameObject target;
    private Rigidbody rb;

    /*private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Find the enemy gameobject, replace "Enemy" with your enemy's tag
        target = GameObject.FindGameObjectWithTag("enemy");
    }*/
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Find all enemy game objects with the tag "enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        // Store the distance to the closest enemy found so far
        float minDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance from this bullet to the enemy
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // If this enemy is closer than the previously found closest enemy, update the target
            if (distance < minDistance)
            {
                minDistance = distance;
                target = enemy;
            }
        }
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
            Destroy(gameObject, 5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy" )
            Destroy(gameObject);
    }
}
