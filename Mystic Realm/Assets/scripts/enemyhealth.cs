using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public healthbar healthbar;
    public GameObject deathParticleEffect;
    public GameObject coinPrefab;
    public int coinsToDrop = 1;
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
                Instantiate(deathParticleEffect, transform.position + Vector3.up, Quaternion.identity);
                Destroy(transform.parent.gameObject);
            }
            for (int i = 0; i < coinsToDrop; i++)
            {
                GameObject spawnedCoin = Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)), Quaternion.Euler(0, 0, 90));

                // Adjust the coin's value based on the enemy's tag
                COIN coinComponent = spawnedCoin.GetComponent<COIN>();
                if (coinComponent != null)
                {
                    coinComponent.SetCoinValueByEnemyTag(this.gameObject.tag);
                }
                if (gamemanager.currentlevel == 0)
                {
                    if (spawnedCoin.transform.position.y < 12f)
                    {
                        spawnedCoin.transform.position = new Vector3(spawnedCoin.transform.position.x, 12f, spawnedCoin.transform.position.z);
                    }
                }
                else if(gamemanager.currentlevel > 0)
                {
                    if (spawnedCoin.transform.position.y < 63f)
                    {
                 
                        spawnedCoin.transform.position = new Vector3(spawnedCoin.transform.position.x, 63f, spawnedCoin.transform.position.z);
                    }
                }
                gamemanager.coincount++;
                coinComponent.StartMovingToPlayer();
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
