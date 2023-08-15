using UnityEngine;

public class COIN : MonoBehaviour
{
    public int value = 1; // You can vary this for different coin values.

    public float rotationSpeed = 50f; // Speed of rotation in degrees per second
    public Transform player; // Reference to the player's Transform
    public float moveSpeed = 5f; // Speed at which coin moves towards the player

    private bool moveToPlayer = false; // Flag to determine if coin should move to player

    private void Start()
    {
        // Assuming your player is tagged "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        // Rotate the coin
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        if (moveToPlayer)
        {
            // Move the coin towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
    public void SetCoinValueByEnemyTag(string enemyTag)
    {
        switch (enemyTag)
        {
            case "ghost":
                value = 5; // Example value for Ghost
                break;
            case "black ghost":
                value = 15; // Example value for Reaper
                break;
            case "reaper":
                value = 30; // Example value for Reaper
                break;
            case "witch":
                value = 20; // Example value for Reaper
                break;
            // Add more cases as needed
            default:
                value = 1; // Default value
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Assuming your player has the tag "Player"
        {
            // Add the coin's value to the player's currency
            PlayerCurrency playerCurrency = other.GetComponent<PlayerCurrency>();
            if (playerCurrency != null)
            {
                playerCurrency.AddCoins(value);
                Destroy(gameObject);  // Destroy the coin after collecting
                gamemanager.coincount--;
            }
        }
        else if (other.CompareTag("plane"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        }
    }
    public void StartMovingToPlayer()
    {
        moveToPlayer = true;
    }
}
