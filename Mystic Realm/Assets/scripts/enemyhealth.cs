using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbar healthbar;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        healthbar.setmaxhealth(maxhealth);
        currenthealth = maxhealth;
    }
    void takedamage(int damage)
    {
        currenthealth -= damage;
        healthbar.sethealth(currenthealth);
        if (currenthealth <= 0)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
            gamemanager.enemyCount--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bullet" )
        {
            takedamage(20);
           
        }
        if(collision.gameObject.tag == "special attack")
        {
            takedamage(100);
        }

    }
}
