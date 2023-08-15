using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerhealth : MonoBehaviour
{
    public int maxhealth = 50;
    public int currenthealth;
    public healthbar healthbar;
    private float lastDamageTime = 0f;     // The last time the tower took damage
    public float damageCooldown = 1f;
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
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
            Debug.Log("game over! ");
            QuitGame();
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (Time.time > lastDamageTime + damageCooldown)
        {
            if (other.CompareTag("ghost"))
            {
                takedamage(10);
                lastDamageTime = Time.time;  // Update the last damage time
            }
            if (other.CompareTag("black ghost"))
            {
                takedamage(20);
                lastDamageTime = Time.time;  // Update the last damage time
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        // Check if enough time has passed since the last damage
        if (Time.time > lastDamageTime + damageCooldown)
        {
            if (other.CompareTag("ghost"))
            {
                takedamage(10);
                lastDamageTime = Time.time;  // Update the last damage time
            }
            if (other.CompareTag("black ghost"))
            {
                takedamage(20);
                lastDamageTime = Time.time;  // Update the last damage time
            }
        }
    }
    public void QuitGame()
    {
        // If we are running in the editor
    #if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
