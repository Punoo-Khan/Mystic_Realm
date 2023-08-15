using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public static int coins = 0;
    public GameObject turretPrefab;
    public int turretCost = 25;  // For example

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && coins >= turretCost)  // Assuming 'T' is the key to spawn turret
        {
            Instantiate(turretPrefab, transform.position + Vector3.right + Vector3.right*5 , Quaternion.identity); // spawns turret to the right of player
            coins -= turretCost;
        }
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        // Optionally, update any UI elements displaying the coin count here.
        Debug.Log("Coins: " + coins);
    }
}
