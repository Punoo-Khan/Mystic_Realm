using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonehealth : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbar healthbar;
    private void Start()
    {
        healthbar.setmaxhealth(maxhealth);
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void takedamage(int damage)
    {
        currenthealth -= damage;
        healthbar.sethealth(currenthealth);
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("LMAO DED CLONE ");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ghost")
        {
            takedamage(10);
        }
        if (collision.gameObject.tag == "black ghost")
        {
            takedamage(20);
        }

    }
}
