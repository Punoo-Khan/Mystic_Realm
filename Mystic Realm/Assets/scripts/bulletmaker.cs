using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 10f;
    public float detectionRadius = 100f;
    public float reloadTime = 1f; // Time between shots
    public int bulletLimit = 5; // Limit number of bullets
    private int bulletCount = 0; // Current number of bullets fired
    private bool canShoot = true; // Whether or not the player can currently shoot

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        if (canShoot )
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "enemy")
                {
                    /*Debug.Log("i am here");*/
                    canShoot = false;
                    bulletCount++;

                    GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                    StartCoroutine(Reload());
                    break;
                }

                i++;
            }
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime); // Wait for the reload time
        canShoot = true; // Allow the player to shoot again
    }
}
