using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigationscript : MonoBehaviour
{
    public Transform tower;
    public NavMeshAgent enemy;
    public float stoppingDistance = 0.5f; // The distance at which the enemy should stop moving towards the tower

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        tower = GameObject.FindGameObjectWithTag("tower").transform;
    }

    void Update()
    {
        // Check the distance to the tower
        float distance = Vector3.Distance(transform.position, tower.position);

        // If the enemy is further away than the stopping distance, move towards the tower
        if (distance > stoppingDistance)
        {
            enemy.destination = tower.position;

        }
        else
        {
            enemy.destination = transform.position; // Stop the enemy
           /* Debug.Log("hello jani");*/
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the tower
        if (collision.gameObject.transform == tower)
        {
          /*  Debug.Log("hello");*/
            enemy.destination = transform.position; // Stop the enemy
        }
    }
}
