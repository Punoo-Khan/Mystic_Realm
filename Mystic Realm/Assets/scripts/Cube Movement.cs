using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody myrigidbody;
    public float Movespeed = 10;
    public Joystick joystick;
    public int maxhealth = 100;
    public int currenthealth;
    public healthbar healthbar;
    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        healthbar.setmaxhealth(maxhealth);
        currenthealth = maxhealth;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate() // All physics goes here
    {
        move();
    }
    private void move()
    {
        Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);

        // Apply the movement to the Rigidbody
        //myrigidbody.MovePosition(myrigidbody.position + movement * Movespeed * Time.deltaTime);
        // cant rotate in this
        myrigidbody.AddForce(movement * Movespeed);

    }
    void takedamage(int damage)
    {
        currenthealth -= damage;
        healthbar.sethealth(currenthealth);
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("LMAO DED LOSER ");
            QuitGame();
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="enemy")
        {
            takedamage(10);
        }

    }
    public void QuitGame()
    {
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
